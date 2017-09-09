using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.VisualBasic.FileIO;

namespace L2Ninja
{
    public enum ObjectType
    {
        Texture
    }
    public partial class UTXBrowserPanel : MetroForm
    {

        String CurrentPath = null;

        String UModelOutput = "";

        DataSet UTXDataSet = new DataSet();
        DataTable UTXDataTable = new DataTable();

        public UTXBrowserPanel(String path)
        {
            CurrentPath = path;
            InitializeComponent();
            FixUI();
        }

        public UTXBrowserPanel()
        {
            InitializeComponent();
            FixUI();
        }

        private void FixUI()
        {
            this.Shown += UTXBrowserPanel_Shown;
            this.StyleManager = MainPanel.GetStyle();
            ThemeUtil.GetInstance().FixGroupBox(groupBox1);
            ThemeUtil.GetInstance().FixGroupBox(groupBox2);
            ThemeUtil.GetInstance().FixGroupBox(groupBox3);
            ThemeUtil.GetInstance().FixGroupBox(groupBox4);
            ThemeUtil.GetInstance().FixGroupBox(groupBox5);
            ThemeUtil.GetInstance().FixGroupBox(groupBox6);
            utxInspectorGrid.Style = MainPanel.GetStyle().Style;
            utxInspectorGrid.Theme = MainPanel.GetStyle().Theme;
        }

        private void UTXBrowserPanel_Shown(object sender, EventArgs e)
        {
            //Setup DataTable
            UTXDataTable.Columns.Add("Id");
            UTXDataTable.Columns.Add("Package");
            UTXDataTable.Columns.Add("Type");
            //Load UTX
            LoadFile();
        }

        private void UTXBrowserPanel_Load(object sender, EventArgs e)
        {
            if (CurrentPath != null)
            {
                inputFileText.Text = CurrentPath;
            }
        }

        protected string ExportObject(string Package, string obj, ObjectType type)
        {
            if(File.Exists(Application.StartupPath+"/includes/umodel/" + Package))
            {
                String EncoderPath = Application.StartupPath + "/includes/umodel/";
                CommandLine cmd = new CommandLine(EncoderPath);
                String ProcessOutput = cmd.Execute("umodel -export " + Package + " " + obj + " -out=temp");
                if(!ProcessOutput.Contains("Exporting objects"))
                {
                    throw new InvalidExpressionException();
                }
                return EncoderPath + "temp/" + Path.GetFileNameWithoutExtension(Package) + "/" + type.ToString() + "/" + obj + ".tga";
            }
            else
            {
                throw new FileNotFoundException();
            }
        }


        protected void LoadFile()
        {
            if(CurrentPath == null) { return; }
            //Copy File to Temp
            String FileName = Path.GetFileName(CurrentPath);
            File.Copy(CurrentPath, Application.StartupPath + "/includes/umodel/" + FileName, true);
            //Change CMD Path to Avoid Spaces Errors
            String EncoderPath = Application.StartupPath + "/includes/umodel/";
            CommandLine cmd = new CommandLine(EncoderPath);
            UModelOutput = cmd.Execute("umodel -list " + FileName);
            //Parse Output
            ParseListOutput(UModelOutput);
        }

        protected void ParseListOutput(String output)
        {
            String[] outputLines = output.Split('\n');
            UTXDataTable.Rows.Clear();
            //Parse Header
            String[] Headers = outputLines[0].Split('\t');
            if(Headers[0].StartsWith("Found") && outputLines.Length >= 3)
            {
                int meshIndex = 2;
                while(outputLines[meshIndex] != "")
                {
                    String MeshLine = Regex.Replace(outputLines[meshIndex], @"\s+", " ").Trim();
                    String[] MeshInfo = MeshLine.Split(' ');
                    UTXDataTable.Rows.Add( new string[] { 
                        MeshInfo[0], //Index
                        MeshInfo[4], //Package
                        MeshInfo[3] //Type
                    });

                    meshIndex++;
                }
                utxInspectorGrid.DataSource = UTXDataTable;
                utxInspectorGrid.DataMember = UTXDataTable.TableName;
                utxInspectorGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Error with File Parsing");
            }
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "UTX Files|*.utx, USX Files|*.usx";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                CurrentPath = ofd.FileName;
                inputFileText.Text = CurrentPath;
                LoadFile();
            }
        }

        private void utxInspectorGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String ObjectName = utxInspectorGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            String TypeString = utxInspectorGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Package = Path.GetFileNameWithoutExtension(CurrentPath);
            ObjectType Type = ObjectType.Texture;
            
            switch (TypeString)
            {
                case "Texture":
                    Type = ObjectType.Texture;
                    break;
                default: Type = ObjectType.Texture; break;
            }
            String ExportPath = Application.StartupPath + "/includes/umodel/temp/"+Package+"/"+Type.ToString()+"/";
            try
            {
                ExportObject(Path.GetFileName(CurrentPath), ObjectName, Type);

                List<String> ExistFiles = Directory.EnumerateFiles(ExportPath).ToList<String>();
                String ExportedFile = null;
                foreach(String file in ExistFiles)
                {
                    String name = Path.GetFileName(file);
                    if(name.StartsWith(ObjectName))
                    {
                        ExportedFile = file;
                        break;
                    }
                }
                if(ExportedFile != null)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = Path.GetFileName(ExportedFile);
                    if(save.ShowDialog() == DialogResult.OK)
                    {
                        //MessageBox.Show(ExportedFile);
                        File.Copy(ExportedFile, save.FileName,true);
                        MessageBox.Show(Type.ToString() + " Exported Successfully");
                    }
                }
            }
            catch(FileNotFoundException notfound)
            {
                MessageBox.Show("Cannot Find That Package");
            }
            catch(InvalidExpressionException exp)
            {
                MessageBox.Show("Invalid File Name Format");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exportSelectedBtn_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in utxInspectorGrid.SelectedRows)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, row.Index);
                utxInspectorGrid_CellContentDoubleClick(this, args);
            }
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            if (searchText.Text.Length > 0)
            { (utxInspectorGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("Package LIKE '%{0}%'", searchText.Text); }
            else
            { searchText.Text = "";(utxInspectorGrid.DataSource as DataTable).DefaultView.RowFilter = "";}
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            (utxInspectorGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("Package LIKE '%{0}%'", searchText.Text);
        }

        private void clearSearchBtn_Click(object sender, EventArgs e)
        {
            searchText.Text = "";
            (utxInspectorGrid.DataSource as DataTable).DefaultView.RowFilter = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(CurrentPath == null || CurrentPath == "" || !File.Exists(CurrentPath))
            {
                MessageBox.Show("Please Load a Valid UTX File");
                return;
            }
            UTXParser parser = new UTXParser();
            string decryptedFile = parser.Decrypt(CurrentPath);
            if(decryptedFile != null)
            {
                if (MessageBox.Show(
                        "File Encrypted Successfully , do you wanna me save it for you ?",
                        "Encryption Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                        == System.Windows.Forms.DialogResult.OK)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save Encrypted UTX File : ";
                    sfd.FileName = Path.GetFileName(decryptedFile);
                    sfd.Filter = "UTX Files |*.utx";
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Copy(decryptedFile, sfd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error with File Parsing");
            }
        }

        private void extractAllBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPath == null)
            {
                return;
            }
            //Copy File to Temp
            String FileName = Path.GetFileName(CurrentPath);
            File.Copy(CurrentPath, Application.StartupPath + "/includes/umodel/" + FileName, true);
            //Change CMD Path to Avoid Spaces Errors
            String EncoderPath = Application.StartupPath + "/includes/umodel/";
            ProcessStartInfo UModelProcessInfo = new ProcessStartInfo();
            UModelProcessInfo.UseShellExecute = false;
            UModelProcessInfo.WorkingDirectory = Application.StartupPath + "/includes/umodel/";
            UModelProcessInfo.FileName = "cmd.exe";
            UModelProcessInfo.Arguments = "/C umodel -export -all " + FileName;
            UModelProcessInfo.RedirectStandardOutput = true;
            UModelProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process UModelProcess = Process.Start(UModelProcessInfo);
            UModelOutput = UModelProcess.StandardOutput.ReadToEnd();
            UModelProcess.WaitForExit();
            this.Focus();
            //Parse Output
            if(UModelOutput.StartsWith("Found"))
            {
                String ExportPath = EncoderPath + "UmodelExport/";
                if(Directory.Exists(ExportPath + Path.GetFileNameWithoutExtension(FileName)))
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowNewFolderButton = true;
                    if(fbd.ShowDialog() == DialogResult.OK)
                    {
                        string Source = ExportPath + Path.GetFileNameWithoutExtension(FileName);
                        string target = fbd.SelectedPath;
                        FileSystem.CopyDirectory(Source, target, UIOption.AllDialogs, UICancelOption.DoNothing);
                        MessageBox.Show("Extracted Objects Saved Successfully");
                    }
                    
                }
            }
        }

        private void viewSelectedBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPath == null) { return; }
            
            //Copy File to Temp if Needed
            String FileName = Path.GetFileName(CurrentPath);
            if (!File.Exists(Application.StartupPath + "/includes/umodel/" + FileName))
            {
                File.Copy(CurrentPath, Application.StartupPath + "/includes/umodel/" + FileName, true);
            }
            //Change CMD Path to Avoid Spaces Errors
            String EncoderPath = Application.StartupPath + "/includes/umodel/";
            CommandLine cmd = new CommandLine(EncoderPath);
            UModelOutput = cmd.Execute("umodel -view " + FileName);
            this.Focus();
        }

        private void utxInspectorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow Row = utxInspectorGrid.Rows[e.RowIndex];
            if(Row.Cells[2].Value.ToString() == ObjectType.Texture.ToString())
            {
                string extracted = ExportObject(Path.GetFileName(CurrentPath), Row.Cells[1].Value.ToString(), ObjectType.Texture);
                if(extracted !=null && File.Exists(extracted))
                {
                    livePreviewBox.Image = TGADecoder.FromFile(extracted);
                }
            }
            else
            {
                livePreviewBox.Image = Properties.Resources.livepreviewplaceholder;
            }
        }
    }
}
