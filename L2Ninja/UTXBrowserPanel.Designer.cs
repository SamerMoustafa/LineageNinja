namespace L2Ninja
{
    partial class UTXBrowserPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UTXBrowserPanel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputFileText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.utxInspectorGrid = new MetroFramework.Controls.MetroGrid();
            this.exportSelectedBtn = new System.Windows.Forms.Button();
            this.extractAllBtn = new System.Windows.Forms.Button();
            this.viewSelectedBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.livePreviewBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utxInspectorGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.livePreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputFileText);
            this.groupBox1.Location = new System.Drawing.Point(302, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input File ";
            // 
            // inputFileText
            // 
            this.inputFileText.Enabled = false;
            this.inputFileText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFileText.Location = new System.Drawing.Point(16, 26);
            this.inputFileText.Name = "inputFileText";
            this.inputFileText.Size = new System.Drawing.Size(410, 27);
            this.inputFileText.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 77);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 29);
            this.button4.TabIndex = 0;
            this.button4.Text = "Decrypt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(12, 36);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(163, 29);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Load File";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.utxInspectorGrid);
            this.groupBox2.Location = new System.Drawing.Point(302, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 446);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inspector";
            // 
            // utxInspectorGrid
            // 
            this.utxInspectorGrid.AllowUserToAddRows = false;
            this.utxInspectorGrid.AllowUserToDeleteRows = false;
            this.utxInspectorGrid.AllowUserToResizeRows = false;
            this.utxInspectorGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.utxInspectorGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.utxInspectorGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.utxInspectorGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.utxInspectorGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.utxInspectorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.utxInspectorGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.utxInspectorGrid.EnableHeadersVisualStyles = false;
            this.utxInspectorGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.utxInspectorGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.utxInspectorGrid.Location = new System.Drawing.Point(19, 30);
            this.utxInspectorGrid.Name = "utxInspectorGrid";
            this.utxInspectorGrid.ReadOnly = true;
            this.utxInspectorGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.utxInspectorGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.utxInspectorGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.utxInspectorGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.utxInspectorGrid.Size = new System.Drawing.Size(407, 397);
            this.utxInspectorGrid.TabIndex = 0;
            this.utxInspectorGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.utxInspectorGrid_CellClick);
            // 
            // exportSelectedBtn
            // 
            this.exportSelectedBtn.Location = new System.Drawing.Point(12, 25);
            this.exportSelectedBtn.Name = "exportSelectedBtn";
            this.exportSelectedBtn.Size = new System.Drawing.Size(163, 29);
            this.exportSelectedBtn.TabIndex = 4;
            this.exportSelectedBtn.Text = "Export Selected";
            this.exportSelectedBtn.UseVisualStyleBackColor = true;
            this.exportSelectedBtn.Click += new System.EventHandler(this.exportSelectedBtn_Click);
            // 
            // extractAllBtn
            // 
            this.extractAllBtn.Location = new System.Drawing.Point(12, 65);
            this.extractAllBtn.Name = "extractAllBtn";
            this.extractAllBtn.Size = new System.Drawing.Size(163, 29);
            this.extractAllBtn.TabIndex = 4;
            this.extractAllBtn.Text = "Extract All";
            this.extractAllBtn.UseVisualStyleBackColor = true;
            this.extractAllBtn.Click += new System.EventHandler(this.extractAllBtn_Click);
            // 
            // viewSelectedBtn
            // 
            this.viewSelectedBtn.Location = new System.Drawing.Point(12, 155);
            this.viewSelectedBtn.Name = "viewSelectedBtn";
            this.viewSelectedBtn.Size = new System.Drawing.Size(163, 29);
            this.viewSelectedBtn.TabIndex = 5;
            this.viewSelectedBtn.Text = "Full Definition";
            this.viewSelectedBtn.UseVisualStyleBackColor = true;
            this.viewSelectedBtn.Click += new System.EventHandler(this.viewSelectedBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.browseBtn);
            this.groupBox3.Location = new System.Drawing.Point(769, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 127);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Basic Features";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.exportSelectedBtn);
            this.groupBox4.Controls.Add(this.extractAllBtn);
            this.groupBox4.Location = new System.Drawing.Point(769, 476);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 110);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Export";
            // 
            // searchText
            // 
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.Location = new System.Drawing.Point(12, 32);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(164, 27);
            this.searchText.TabIndex = 0;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.searchText);
            this.groupBox6.Location = new System.Drawing.Point(769, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(186, 72);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.livePreviewBox);
            this.groupBox5.Controls.Add(this.viewSelectedBtn);
            this.groupBox5.Location = new System.Drawing.Point(769, 277);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 193);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Live Preview";
            // 
            // livePreviewBox
            // 
            this.livePreviewBox.ErrorImage = global::L2Ninja.Properties.Resources.livepreviewplaceholder;
            this.livePreviewBox.Image = global::L2Ninja.Properties.Resources.livepreviewplaceholder;
            this.livePreviewBox.InitialImage = global::L2Ninja.Properties.Resources.livepreviewplaceholder;
            this.livePreviewBox.Location = new System.Drawing.Point(12, 19);
            this.livePreviewBox.Name = "livePreviewBox";
            this.livePreviewBox.Size = new System.Drawing.Size(163, 130);
            this.livePreviewBox.TabIndex = 0;
            this.livePreviewBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::L2Ninja.Properties.Resources.sideimage;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 526);
            this.panel1.TabIndex = 0;
            // 
            // UTXBrowserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 606);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UTXBrowserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "L2Ninja - UTX Browser";
            this.Load += new System.EventHandler(this.UTXBrowserPanel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utxInspectorGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.livePreviewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox inputFileText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exportSelectedBtn;
        private System.Windows.Forms.Button extractAllBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button viewSelectedBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.GroupBox groupBox6;
        private MetroFramework.Controls.MetroGrid utxInspectorGrid;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox livePreviewBox;
    }
}