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

namespace L2Ninja
{
    public partial class PatchDialog : MetroForm
    {
        public PatchDialog()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
