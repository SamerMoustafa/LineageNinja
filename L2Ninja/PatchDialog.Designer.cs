namespace L2Ninja
{
    partial class PatchDialog
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.filePathText = new MetroFramework.Controls.MetroTextBox();
            this.browseBtn = new MetroFramework.Controls.MetroButton();
            this.patchText = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(211, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(213, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "How you wanna Import the Patch ?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filePathText);
            this.groupBox1.Controls.Add(this.browseBtn);
            this.groupBox1.Location = new System.Drawing.Point(34, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From a File ?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.patchText);
            this.groupBox2.Location = new System.Drawing.Point(34, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Or by Pasting ?";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(461, 424);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(142, 32);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseSelectable = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(34, 424);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(142, 32);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Apply Patch";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // filePathText
            // 
            this.filePathText.Enabled = false;
            this.filePathText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.filePathText.Lines = new string[0];
            this.filePathText.Location = new System.Drawing.Point(18, 26);
            this.filePathText.MaxLength = 32767;
            this.filePathText.Name = "filePathText";
            this.filePathText.PasswordChar = '\0';
            this.filePathText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filePathText.SelectedText = "";
            this.filePathText.Size = new System.Drawing.Size(416, 28);
            this.filePathText.TabIndex = 3;
            this.filePathText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filePathText.UseSelectable = true;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(440, 26);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(110, 28);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseSelectable = true;
            this.browseBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // patchText
            // 
            this.patchText.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.patchText.Lines = new string[0];
            this.patchText.Location = new System.Drawing.Point(18, 29);
            this.patchText.MaxLength = 32767;
            this.patchText.Multiline = true;
            this.patchText.Name = "patchText";
            this.patchText.PasswordChar = '\0';
            this.patchText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.patchText.SelectedText = "";
            this.patchText.Size = new System.Drawing.Size(532, 169);
            this.patchText.TabIndex = 4;
            this.patchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.patchText.UseSelectable = true;
            // 
            // PatchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 485);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "PatchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patch Request";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton cancelBtn;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox filePathText;
        private MetroFramework.Controls.MetroButton browseBtn;
        private MetroFramework.Controls.MetroTextBox patchText;
    }
}