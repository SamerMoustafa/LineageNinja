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
    public partial class INIEditorPanel : MetroForm
    {
        String FilePath;
        public INIEditorPanel()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
        }

        public INIEditorPanel(string filePath)
        {
            FilePath = filePath;
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
        }

        protected void LoadFile()
        {
            if(!File.Exists(FilePath))
            {
                MessageBox.Show("Error", "Cannot Find Attached File");
                return;
            }
            L2Encdec encDec = new L2Encdec();
            encDec.AttachFile(FilePath);
            string DecryptedFile = encDec.Decrypt();
            if(!File.Exists(DecryptedFile))
            {
                MessageBox.Show("Error", "Failed to Decrypt File");
                return;
            }
            String Contents = File.ReadAllText(DecryptedFile);
            editorText.Text = Contents;
        }

        private void INIEditorPanel_Load(object sender, EventArgs e)
        {
            if(FilePath != null)
            {
                LoadFile();
            }
        }
    }
}
