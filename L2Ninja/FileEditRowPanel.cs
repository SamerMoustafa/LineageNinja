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
            for(int i = SourceGrid.Columns.Count - 1; i >= 0; i--)
            {
                string niceLabel = SourceGrid.Columns[i].HeaderText;
                Panel tempPanel = new Panel();
                tempPanel.Height = 50;
                tempPanel.Width = editElementPanel.Width;
                Label tempLabel = new Label();
                tempLabel.Text = niceLabel;
                tempPanel.Controls.Add(tempLabel);
                if (niceLabel.StartsWith("rgba"))
                {
                    tempLabel.Text = "Color";
                    string color = Row.Cells[i].Value.ToString();
                    color = Row.Cells[(i+1)].Value.ToString() + color;
                    color = Row.Cells[(i+2)].Value.ToString() + color;
                    color = Row.Cells[(i+3)].Value.ToString() + color;
                    i -= 2;
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
            Color color = Color.FromArgb(Int32.Parse(Value, NumberStyles.HexNumber));
            //Color backColor = Color.FromArgb(Int32.Parse(Value.Substring(0, 6) + "FF", NumberStyles.HexNumber));
            tempTextBox.Location = new Point(100, 0);
            tempTextBox.Text = Value;
            //tempTextBox.BackColor = backColor;
            tempTextBox.TabIndex = 1;
            parent.Controls.Add(tempTextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowDialog();
        }
    }
}
