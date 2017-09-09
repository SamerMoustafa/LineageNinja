using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace L2Ninja
{
    public partial class FileEditPanel : MetroForm
    {
        int ColumnWidth = 100;

        int ColumnMaximumWidth = 100;

        bool Exporting = false;

        public String CurrentFilePath { get; protected set; }

        public String CurrentFile { get; protected set; }

        public FileEditPanel()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
            ThemeUtil.GetInstance().FixControls(this.Controls);
            ThemeUtil.GetInstance().FixControl(metroLabel3);
            ThemeUtil.GetInstance().FixControl(metroLabel1);
            ThemeUtil.GetInstance().FixControl(metroLabel4);
            ThemeUtil.GetInstance().FixControl(columnsLabel);
            ThemeUtil.GetInstance().FixControl(recordsLabel);
            if (ThemeUtil.GetInstance().IsDark())
            {
                ThemeUtil.GetInstance().FixGroupBox(groupBox1);
                menuStrip1.BackColor = ColorTranslator.FromHtml("#202020");
                menuStrip1.ForeColor = Color.LightGray;
            }
            //fileEditorGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //CTRL+O => Open
            if (keyData == (Keys.Control | Keys.O))
            {
                openToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }
            //CTRL+F => Find
            else if (keyData == (Keys.Control | Keys.F))
            {
                findToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }
            //CTRL+S => Save
            else if (keyData == (Keys.Control | Keys.S))
            {
                saveToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }
            //CTRL+E => Export as Text
            else if (keyData == (Keys.Control | Keys.E))
            {
                saveAstxtToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }
            //CTRL+P => Apply Patch
            else if (keyData == (Keys.Control | Keys.P))
            {
                applyPatchToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if(ofd.FileName.EndsWith(".ini") || ofd.FileName.EndsWith(".int"))
                {
                    INIEditorPanel iniEditor = new INIEditorPanel(ofd.FileName);
                    iniEditor.Show();
                    return;
                }
                LoadFile(ofd.FileName);
            }
        }

        public void LoadFile(String filePath)
        {
            L2Encdec encrypter = new L2Encdec();
            try
            {
                CurrentFilePath = filePath;
                CurrentFile = Path.GetFileName(filePath);
                currentFileLabel.Text = CurrentFile;
                encrypter.AttachFile(filePath);
                string decryptedFile = encrypter.Decrypt();
                if (decryptedFile != null)
                {
                    L2ASM asm = new L2ASM();
                    asm.AttachFile(decryptedFile);
                    String txtFile = asm.Decrypt((Chronicle)chronicleCombo.SelectedIndex);
                    if (txtFile != null) { ParseTextFile(txtFile); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ParseTextFile(string txtFile)
        {
            Task parseTask = Task.Factory.StartNew(() =>
            {
                StreamReader reader = new StreamReader(txtFile);
                String HeaderLine = reader.ReadLine();
                String[] HeaderColumns = HeaderLine.Split('\t');
                String LineContent = reader.ReadLine();
                DataTable Table = new DataTable();
                ColumnMaximumWidth = (int)(65535 / HeaderColumns.Length) -1;
                ColumnWidth = (ColumnMaximumWidth > 100) ? 100 : ColumnMaximumWidth;
                foreach (String column in HeaderColumns) { Table.Columns.Add(column); }
                if (LineContent == null) { MessageBox.Show("Null Data"); }
                while (LineContent != null)
                {
                    if (LineContent.Length == 0) { LineContent = reader.ReadLine(); continue; }
                    String[] Data = LineContent.Split('\t');
                    Table.Rows.Add(Data);
                    LineContent = reader.ReadLine();
                }
                this.Invoke((MethodInvoker) delegate{
                    fileEditorGrid.ColumnAdded += FileEditorGrid_ColumnAdded;
                    fileEditorGrid.ColumnWidthChanged += FileEditorGrid_ColumnWidthChanged;
                    fileEditorGrid.SuspendLayout();
                    fileEditorGrid.DataSource = Table;
                    fileEditorGrid.ResumeLayout(false);
                    recordsLabel.Text = Table.Rows.Count.ToString();
                    columnsLabel.Text = Table.Columns.Count.ToString();
                });
            }); 
        }

        private void FileEditorGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if(e.Column.Width >= ColumnMaximumWidth) { e.Column.Width = ColumnMaximumWidth; }
        }

        private void FileEditorGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = ColumnWidth;
        }

        private void FileEditPanel_Load(object sender, EventArgs e)
        {
            chronicleCombo.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.DefaultChronicle);
        }

        private void chronicleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultChronicle = chronicleCombo.SelectedIndex.ToString();
            Properties.Settings.Default.Save();
        }

        private void fileEditorGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FileEditRowPanel editRow = new FileEditRowPanel(fileEditorGrid, e.RowIndex);
            editRow.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CurrentFile == null)
            {
                MessageBox.Show("Where should i search ????", "OMG", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            SearchDialog search = new SearchDialog();
            search.OnConfirm += Search_OnConfirm;
            search.ShowDialog();
        }

        private void Search_OnConfirm(string message)
        {
            Task searchTask = Task.Factory.StartNew(() => {
                this.Invoke((MethodInvoker)delegate {
                    taskLabel.Text = "Searching for " + message.Substring(0, (message.Length > 12) ? 12 : message.Length) + "...";
                });
                foreach (DataGridViewRow Row in fileEditorGrid.Rows)
                {
                    if (Row.Selected) { this.Invoke((MethodInvoker)delegate { Row.Selected = false; }); }
                    foreach(DataGridViewCell Cell in Row.Cells)
                    {
                        if(Cell.Value != null && Cell.Value.ToString().Contains(message))
                        { this.Invoke((MethodInvoker) delegate { Row.Selected = true; }); }
                    }
                }
                this.Invoke((MethodInvoker)delegate {
                    MessageBox.Show("Search Process Done, Your Results are now Selected for you\n Found : " + fileEditorGrid.SelectedRows.Count.ToString() + " Results");
                    taskLabel.Text = "None";
                });
            });
        }

        private void applyPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CurrentFile == null)
            {
                MessageBox.Show("Come on you wanna apply patch to nothing ?!!!! \n 1st. Load a File \n 2nd. Quit Alchohol", "Really ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            PatchDialog patch = new PatchDialog();
            patch.ShowDialog();
        }

        private void SetState(string state)
        {
            if (InvokeRequired)
            { this.Invoke((MethodInvoker)delegate { taskLabel.Text = state; }); }
            else { taskLabel.Text = state; }
        }

        private void saveAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Exporting) { MessageBox.Show("I'm Already Exporting, could you wait please ?", "Just Moments"); return;}
            if(CurrentFile == null)
            {
                MessageBox.Show("Well here is a hard question for you .. \n do we have anything to export ?", "Surprise!");
                return;
            }
            Exporting = true;
            Task saveTextTask = Task.Factory.StartNew(() => {
                String DumpFileName = "dump-" + Util.GetUnixTimestamp().ToString() + ".dump";
                SetState("Export: Gathering Data..");
                DataTable Table = (fileEditorGrid.DataSource as DataTable).Copy();
                SetState("Export: Creating Export Dump File ...");
                String Header = "";
                SetState("Export: Getting Headers ...");
                foreach(DataColumn Column in Table.Columns)
                {
                    Header += Column.ColumnName + '\t';
                }
                Header = Header.Trim('\t');
                Header += '\n';
                SetState("Export: Writing Data ...");
                using (Stream DumpStream = File.Open(Application.StartupPath + "/Temp/" + DumpFileName, FileMode.Create, FileAccess.Write))
                {
                    Byte[] Buffer = Encoding.ASCII.GetBytes(Header);
                    DumpStream.Write(Buffer, 0, Buffer.Length);
                    foreach(DataRow Row in Table.Rows)
                    {
                        String Line = "";
                        foreach(String cellValue in Row.ItemArray.Cast<String>())
                        {
                            Line += cellValue + '\t';
                        }
                        Line = Line.Trim('\t');
                        Line += '\n';
                        Buffer = Encoding.ASCII.GetBytes(Line);
                        DumpStream.Write(Buffer, 0, Buffer.Length);
                    }
                }
                SetState("Dump File Created, Ask for Save...");
                this.Invoke((MethodInvoker)delegate { 
                    if(
                        MessageBox.Show("Dump Created, Would you like to Save it for you ?", "Successfull", MessageBoxButtons.OKCancel,MessageBoxIcon.Information)
                        == DialogResult.OK
                    )
                    {
                        SaveFileDialog Save = new SaveFileDialog();
                        Save.FileName = Path.GetFileNameWithoutExtension(CurrentFile);
                        Save.Title = "Export to ...";
                        Save.Filter = "Text Files (*.txt)|*.txt";
                        Save.DefaultExt = "txt";
                        if (Save.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(Application.StartupPath + "/Temp/" + DumpFileName, Save.FileName, true);
                            MessageBox.Show("File Saved Successfully", "Done");
                        }
                    }

                });
                Exporting = false;
            });



        }

        private void openFileCTRLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(this, new EventArgs());
        }

        private string CreateDumpFile()
        {
            if (Exporting) { MessageBox.Show("I'm Already Dumping a file, could you wait please ?", "Just Moments"); return null; }
            if (CurrentFile == null)
            {
                MessageBox.Show("Well here is a hard question for you .. \n do we have anything to export ?", "Surprise!");
                return null;
            }
            Exporting = true;
            String DumpFileName = "dump-" + Util.GetUnixTimestamp().ToString() + ".dump";
            SetState("Export: Gathering Data..");
            DataTable Table = (fileEditorGrid.DataSource as DataTable).Copy();
            SetState("Export: Creating Export Dump File ...");
            String Header = "";
            SetState("Export: Getting Headers ...");
            foreach (DataColumn Column in Table.Columns)
            {
                Header += Column.ColumnName + '\t';
            }
            Header = Header.Trim('\t');
            Header += '\n';
            SetState("Export: Writing Data ...");
            using (Stream DumpStream = File.Open(Application.StartupPath + "/Temp/" + DumpFileName, FileMode.Create, FileAccess.Write))
            {
                Byte[] Buffer = Encoding.ASCII.GetBytes(Header);
                DumpStream.Write(Buffer, 0, Buffer.Length);
                foreach (DataRow Row in Table.Rows)
                {
                    String Line = "";
                    foreach (String cellValue in Row.ItemArray.Cast<String>())
                    {
                        Line += cellValue + '\t';
                    }
                    Line = Line.Trim('\t');
                    Line += '\n';
                    Buffer = Encoding.ASCII.GetBytes(Line);
                    DumpStream.Write(Buffer, 0, Buffer.Length);
                }
            }
            SetState("Dump File Created");
            Exporting = false;
            return DumpFileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                String dump = CreateDumpFile();
                if(dump != null && File.Exists(Application.StartupPath + "/Temp/" + dump))
                {
                    String CopyFile = Application.StartupPath + "/Temp/" + Path.GetFileNameWithoutExtension(CurrentFile) + ".dump";
                    File.Copy(Application.StartupPath + "/Temp/" + dump, CopyFile, true);
                    SetState("Assembling Dat File");
                    Chronicle chronicle = (Chronicle)Convert.ToInt32(Properties.Settings.Default.DefaultChronicle);
                    L2ASM asm = new L2ASM();
                    asm.AttachFile(CopyFile);
                    string assembledFile = asm.Encrypt(chronicle);
                    if(assembledFile != null && File.Exists(assembledFile))
                    {
                        L2Encdec encdec = new L2Encdec();
                        encdec.AttachFile(assembledFile);
                        string EncryptedFile = encdec.EncryptDat();
                        if(EncryptedFile != null && File.Exists(EncryptedFile))
                        {
                            String FinalFilePath = Application.StartupPath + "/Temp/" + CurrentFile;
                            File.Copy(EncryptedFile, FinalFilePath, true);
                            DialogResult result = MessageBox.Show("Would you Like to Overwrite the Original File ?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(result == DialogResult.Yes)
                            {
                                File.Copy(FinalFilePath, CurrentFilePath, true);
                                MessageBox.Show("File Successfully Updated");
                            }
                            else if (result == DialogResult.No)
                            {
                                SaveFileDialog Save = new SaveFileDialog();
                                Save.FileName = Path.GetFileNameWithoutExtension(CurrentFile);
                                Save.Title = "Save to ...";
                                Save.Filter = "Data Files (*.dat)|*.dat";
                                Save.DefaultExt = "dat";
                                DialogResult res = Save.ShowDialog();
                                if(res == DialogResult.OK)
                                {
                                    File.Copy(FinalFilePath, Save.FileName, true);
                                }
                            }
                        }
                    }

                }
            });
        }
    }
}
