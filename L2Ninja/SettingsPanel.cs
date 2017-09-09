using MetroFramework.Forms;
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
using System.Diagnostics;

namespace L2Ninja
{
    public partial class SettingsPanel : MetroForm
    {
        public SettingsPanel()
        {
            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
            metroTabControl1.StyleManager = MainPanel.GetStyle();
            metroTabPage1.StyleManager = MainPanel.GetStyle();
            metroTabPage2.StyleManager = MainPanel.GetStyle();
            metroTabPage3.StyleManager = MainPanel.GetStyle();
        }

        private void SettingsPanel_Load(object sender, EventArgs e)
        {
            foreach(string Theme in Enum.GetNames(typeof(MetroFramework.MetroThemeStyle)))
            {
                themeCombo.Items.Add(Theme);
            }
            themeCombo.SelectedIndex = Properties.Settings.Default.theme;
            foreach (string Style in Enum.GetNames(typeof(MetroFramework.MetroColorStyle)))
            {
                styleCombo.Items.Add(Style);
            }
            styleCombo.SelectedIndex = Properties.Settings.Default.style;
        }

        private void saveAppearanceBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.theme = themeCombo.SelectedIndex;
            Properties.Settings.Default.style = styleCombo.SelectedIndex;
            Properties.Settings.Default.Save();
            DialogResult result = MessageBox.Show("Application need to restart to load your Appearance, Restart Now ?", "Restart Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(Application.StartupPath + "\\L2Ninja.exe");
                    Process.GetCurrentProcess().Kill();
                } catch { }
            }
            this.Refresh();
        }
    }
}
