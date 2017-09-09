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
    public partial class BMPToolPanel : MetroForm
    {
        protected String FilePath = null;
        protected String ModifiedPath = null;
        protected bool IsEncrypted = true;
        public BMPToolPanel()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
            this.Refresh();
            this.FocusMe();
        }

        public void Attach(String bmpFile)
        {
            FilePath = bmpFile;
            filePathText.Text = FilePath;
            try
            { 
                previewBox.Image = Image.FromFile(FilePath);
                IsEncrypted = false;
            }
            catch(Exception ex)
            {
                IsEncrypted = true;
                //Try to Encrypt
                L2Encdec encdec = new L2Encdec();
                encdec.AttachFile(FilePath);
                ModifiedPath = encdec.Decrypt();
                if(ModifiedPath != null || File.Exists(ModifiedPath))
                {
                    try
                    {
                        previewBox.Image = Image.FromFile(ModifiedPath);
                    }
                    catch(Exception ex2)
                    {
                        MessageBox.Show("Malformed BMP File", "Error");
                        return;
                    }
                }
            }
            finally
            {
                stateLabel.Text = (IsEncrypted) ? "Encrypted" : "Decrypted";
                encryptBtn.Enabled = !IsEncrypted;
                decryptBtn.Enabled = IsEncrypted;
                //Transparent Key
                Bitmap bitmap = ((Bitmap)previewBox.Image);
                bitmap.MakeTransparent(Color.FromArgb(0, 255, 0));
                previewBox.Image = bitmap;
            }
        }
        

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Replacement";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap Files .bmp|*.bmp";
            ofd.Title = "Load your BMP File ..";
            DialogResult result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                Attach(ofd.FileName);
            }
        }

        private void previewBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (IsEncrypted)
            {
                SaveFileDialog Save = new SaveFileDialog();
                Save.Title = "Save Decrypted Splash...";
                
                Save.Filter = "Bitmap|*.bmp";
                Save.DefaultExt = ".bmp";
                Save.FileName = Path.GetFileName(FilePath);
                DialogResult result = Save.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.Copy(ModifiedPath, Save.FileName, true);
                }
            }
            else { MessageBox.Show("It's Already a Decrypted Image"); }
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if(!IsEncrypted)
            {
                L2Encdec encdec = new L2Encdec();
                encdec.AttachFile(FilePath);
                string encyrptedPath = encdec.EncryptSplash();
                //TODO

            }
        }
    }
}
