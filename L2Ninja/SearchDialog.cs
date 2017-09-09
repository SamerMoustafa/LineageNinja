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
    public partial class SearchDialog : MetroForm
    {

        public delegate void OnCancelDelegate();

        public event OnCancelDelegate OnCancel;

        public delegate void OnConfirmDelegate(string message);

        public event OnConfirmDelegate OnConfirm;

        public SearchDialog()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try { OnCancel(); } catch (Exception) { }
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try { OnConfirm(searchText.Text); } catch (Exception) { }
            this.Close();
        }
    }
}
