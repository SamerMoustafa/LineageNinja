using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2Ninja
{
    class ThemeUtil
    {
        protected static ThemeUtil _Instance = new ThemeUtil();

        protected ThemeUtil() { }

        public static ThemeUtil GetInstance() { return _Instance; }
        public void LoadTheme()
        {
            MainPanel.GetStyle().Theme = (MetroThemeStyle)Properties.Settings.Default.theme;
            MainPanel.GetStyle().Style = (MetroColorStyle)Properties.Settings.Default.style;
        }

        public bool IsDark()
        {
            return ((MetroThemeStyle)Properties.Settings.Default.theme == MetroThemeStyle.Dark);
        }
        public void FixGroupBox(GroupBox group)
        {
            group.Paint += Group_Paint;
        }

        private void Group_Paint(object sender, PaintEventArgs e)
        {
            GroupBox group = (GroupBox)sender;
            e.Graphics.Clear(Color.Transparent);
            if(IsDark())
            {
                Color backColor = ColorTranslator.FromHtml("#111111");
                e.Graphics.Clear(backColor);
                e.Graphics.DrawString(group.Text, group.Font, Brushes.DarkGray, 0, 0);
            }
            else
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawString(group.Text, group.Font, Brushes.Black, 0, 0);
            }
            
        }

        public void FixControls(Control.ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                FixControl(c);
            }
        }

        public void FixControl(Control control)
        {
            //Lables Fix
            if (control is MetroLabel)
            {
                if(IsDark())
                {
                    ((MetroLabel)control).UseCustomBackColor = true;
                    ((MetroLabel)control).UseCustomForeColor = true;
                    ((MetroLabel)control).ForeColor = Color.LightGray;
                    ((MetroLabel)control).UseStyleColors = false;
                    ((MetroLabel)control).BackColor = Color.Transparent;
                }
                
            }
            else if (control is GroupBox || control is MenuStrip)
            {
                FixControls(control.Controls);
            }
        }
    }
}
