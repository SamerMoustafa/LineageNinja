using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Components;

namespace L2Ninja
{
    public partial class MainPanel : MetroForm
    {

        protected static MainPanel _Instance;

        public MainPanel()
        {
            _Instance = this;
            InitializeComponent();
            this.StyleManager = ninjaStyleManager;
            ThemeUtil.GetInstance().LoadTheme();
            //ThemeUtil.GetInstance().FixGroupBox(groupBox1);
            ThemeUtil.GetInstance().FixGroupBox(groupBox2);
            ThemeUtil.GetInstance().FixGroupBox(groupBox3);
            if(ThemeUtil.GetInstance().IsDark())
            {
                menuStrip1.BackColor = ColorTranslator.FromHtml("#202020");
                menuStrip1.ForeColor = Color.LightGray;
            }
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
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
        
        public static MetroStyleManager GetStyle()
        {
            return _Instance.ninjaStyleManager;
        }
        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ninjaStyleManager.Theme = (MetroThemeStyle)Properties.Settings.Default.theme;
            ninjaStyleManager.Style = (MetroColorStyle)Properties.Settings.Default.style;
        }



        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void utxEncryptBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "UTX Files |*.utx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UTXParser parser = new UTXParser();
                string encryptedFile = parser.Encrypt(ofd.FileName);
                if (encryptedFile != null)
                {
                    if (MessageBox.Show(
                        "File Encrypted Successfully , do you wanna me save it for you ?",
                        "Encryption Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) 
                        == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = "Save Encrypted UTX File : ";
                        sfd.FileName = Path.GetFileName(encryptedFile);
                        sfd.Filter = "UTX Files |*.utx";
                        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            File.Copy(encryptedFile, sfd.FileName); 
                        }
                    }
                }
                
            }
        }

        private void utxBrowserBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "UTX Files |*.utx|USX Files |*.usx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UTXBrowserPanel browser = new UTXBrowserPanel(ofd.FileName);
                browser.ShowDialog();
            }
        }

        private void uTXBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UTXBrowserPanel browser = new UTXBrowserPanel();
            browser.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fileEditBtn_Click(object sender, EventArgs e)
        {
            FileEditPanel fileedit = new FileEditPanel();
            fileedit.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsPanel settings = new SettingsPanel();
            settings.ShowDialog();
            settings.Dispose();
        }

        private void dragNDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            String[] FilesPathes = (String[])e.Data.GetData(DataFormats.FileDrop);
            //Detect non Files Drop
            if (FilesPathes == null ||FilesPathes.Length == 0) { MessageBox.Show("You can only Drop Files", "Error"); return; }
            //@TODO: Support Multi File Drop
            String Extension = Path.GetExtension(FilesPathes[0]).Substring(1);
            switch (Extension.ToLower())
            {
                case "bmp":
                    BMPToolPanel bmpTool = new BMPToolPanel();
                    bmpTool.Attach(FilesPathes[0]);
                    bmpTool.Show();
                    break;
                default:
                    MessageBox.Show("Cannot Find Associated Handler for this File Type");
                    break;
            }

        }

        private void dragNDropPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void bMPToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BMPToolPanel bmpTool = new BMPToolPanel();
            bmpTool.Show();
        }

        private void utxDecryptBtn_Click(object sender, EventArgs e)
        {
            string btnText = utxDecryptBtn.Text;
            utxDecryptBtn.Text = "Processiong";
            utxDecryptBtn.Enabled = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "UTX Files |*.utx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UTXParser parser = new UTXParser();
                string decryptedFile = parser.Decrypt(ofd.FileName);
                if (decryptedFile != null)
                {
                    if (MessageBox.Show(
                        "File Decrypted Successfully , do you wanna me save it for you ?",
                        "Decryption Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
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

            }
            utxDecryptBtn.Enabled = true;
            utxDecryptBtn.Text = btnText;
        }

        private void batchDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a File Contains L2 Files to Encrypt";
            fbd.ShowDialog();
        }
    }
}
