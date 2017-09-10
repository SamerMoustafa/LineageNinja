namespace L2Ninja
{
    partial class FileEditRowPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.editElementPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editElementPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 504);
            this.panel1.TabIndex = 0;
            // 
            // editElementPanel
            // 
            this.editElementPanel.AutoScroll = true;
            this.editElementPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editElementPanel.Location = new System.Drawing.Point(0, 0);
            this.editElementPanel.Name = "editElementPanel";
            this.editElementPanel.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.editElementPanel.Size = new System.Drawing.Size(513, 437);
            this.editElementPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cancelBtn);
            this.panel3.Controls.Add(this.saveBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 67);
            this.panel3.TabIndex = 1;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(138, 17);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(116, 34);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(3, 17);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(116, 34);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::L2Ninja.Properties.Resources.sideimage;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(513, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 504);
            this.panel2.TabIndex = 0;
            // 
            // FileEditRowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 584);
            this.Controls.Add(this.panel1);
            this.Name = "FileEditRowPanel";
            this.Text = "Edit Entry";
            this.Load += new System.EventHandler(this.FileEditRowPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel editElementPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cancelBtn;
    }
}