using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MetroFramework.Forms;
using System.Globalization;
using OpenPainter.ColorPicker;

namespace L2Ninja
{
    public partial class FileEditRowPanel : MetroForm
    {
        protected int RowIndex;
        protected DataGridView SourceGrid;
        public FileEditRowPanel(DataGridView sourceGrid, int rowIndex)
        {
            SourceGrid = sourceGrid;
            RowIndex = rowIndex;

            InitializeComponent();
            this.StyleManager = MainPanel.GetStyle();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileEditRowPanel_Load(object sender, EventArgs e)
        {
            DataGridViewRow Row = SourceGrid.Rows[RowIndex];
            if(ThemeUtil.GetInstance().IsDark())
            {
                
            }
            for(int i = SourceGrid.Columns.Count - 1; i >= 0; i--)
            {
                string niceLabel = SourceGrid.Columns[i].HeaderText;
                Panel tempPanel = new Panel();
                tempPanel.Height = 50;
                tempPanel.Width = editElementPanel.Width;
                Label tempLabel = new Label();
                if(ThemeUtil.GetInstance().IsDark())
                {
                    tempLabel.BackColor = Color.Transparent;
                    tempLabel.ForeColor = Color.White;
                }
                tempLabel.Text = niceLabel;
                tempPanel.Controls.Add(tempLabel);
                if (niceLabel.StartsWith("rgba") || niceLabel.StartsWith("rgb"))
                {
                    tempLabel.Text = "Color";
                    string color = Row.Cells[i].Value.ToString().PadRight(2, 'F');
                    color = Row.Cells[(i-1)].Value.ToString().PadRight(2, 'F') + color;
                    color = Row.Cells[(i-2)].Value.ToString().PadRight(2, 'F') + color;
                    //Add Alpha
                    if (niceLabel.StartsWith("rgba")) { color = Row.Cells[(i - 3)].Value.ToString() + color; }
                    i -= (niceLabel.StartsWith("rgba")) ? 3 : 2;
                    CreateColorEditor(tempPanel, color);
                }
                else
                {
                    TextBox tempTextBox = new TextBox();
                    tempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    tempTextBox.Size = new System.Drawing.Size(360, 26);
                    tempTextBox.Location = new Point(100, 0);
                    tempTextBox.Text = Row.Cells[i].Value.ToString();
                    tempTextBox.TabIndex = 1;
                    tempPanel.Controls.Add(tempTextBox);
                }            
                editElementPanel.Controls.Add(tempPanel);
                tempPanel.Dock = DockStyle.Top;
            }
            
            
        }

        private void CreateColorEditor(Panel parent, string Value)
        {
            TextBox tempTextBox = new TextBox();
            tempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tempTextBox.Size = new System.Drawing.Size(360, 26);
            Color EntryColor = System.Drawing.ColorTranslator.FromHtml("#"+ Value.Substring(0, 6));
            //Color color = Color.FromArgb(Int32.Parse(Value, NumberStyles.HexNumber));
            //Color backColor = Color.FromArgb(Int32.Parse(Value.Substring(0, 6), NumberStyles.HexNumber));
            tempTextBox.Location = new Point(100, 0);
            tempTextBox.Text = Value;
            tempTextBox.BackColor = EntryColor;
            tempTextBox.TabIndex = 1;
            tempTextBox.Tag = (Value.Length == 6) ? "rgb" : "rgba";
            tempTextBox.DoubleClick += TempTextBox_DoubleClick;
            parent.Controls.Add(tempTextBox);
        }

        private void TempTextBox_DoubleClick(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                switch(((TextBox)sender).Tag.ToString())
                {
                    case null:

                        break;

                    case "rgb":
                        frmColorPicker picker = new frmColorPicker(((TextBox)sender).BackColor);
                        picker.Text = "[L2Ninja] Select RGB Color";
                        picker.ShowDialog();
                        ((TextBox)sender).BackColor = picker.PrimaryColor;
                        ((TextBox)sender).Text = ColorTranslator.ToHtml(picker.PrimaryColor).Substring(1);
                            break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowDialog();
        }
    }
}
