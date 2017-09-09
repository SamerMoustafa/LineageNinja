namespace L2Ninja
{
    partial class BMPToolPanel
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
            this.filePathText = new MetroFramework.Controls.MetroTextBox();
            this.loadFileBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.stateLabel = new MetroFramework.Controls.MetroLabel();
            this.decryptBtn = new MetroFramework.Controls.MetroButton();
            this.encryptBtn = new MetroFramework.Controls.MetroButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.replaceBtn = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // filePathText
            // 
            this.filePathText.Enabled = false;
            this.filePathText.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.filePathText.Lines = new string[0];
            this.filePathText.Location = new System.Drawing.Point(316, 67);
            this.filePathText.MaxLength = 32767;
            this.filePathText.Name = "filePathText";
            this.filePathText.PasswordChar = '\0';
            this.filePathText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filePathText.SelectedText = "";
            this.filePathText.Size = new System.Drawing.Size(394, 34);
            this.filePathText.TabIndex = 0;
            this.filePathText.UseSelectable = true;
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Location = new System.Drawing.Point(716, 66);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(112, 35);
            this.loadFileBtn.TabIndex = 1;
            this.loadFileBtn.Text = "Load File";
            this.loadFileBtn.UseSelectable = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel1.Location = new System.Drawing.Point(316, 119);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Preview";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel2.Location = new System.Drawing.Point(582, 119);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "File State Detection :";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.BackColor = System.Drawing.Color.Transparent;
            this.stateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.stateLabel.Location = new System.Drawing.Point(716, 118);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(46, 19);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "Empty";
            this.stateLabel.UseCustomBackColor = true;
            this.stateLabel.UseCustomForeColor = true;
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(613, 567);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(97, 31);
            this.decryptBtn.TabIndex = 1;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseSelectable = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(724, 567);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(97, 31);
            this.encryptBtn.TabIndex = 1;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseSelectable = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::L2Ninja.Properties.Resources.sideimage;
            this.pictureBox2.Location = new System.Drawing.Point(23, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(265, 535);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // previewBox
            // 
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.ErrorImage = global::L2Ninja.Properties.Resources.pictureboxplaceholder;
            this.previewBox.Image = global::L2Ninja.Properties.Resources.pictureboxplaceholder;
            this.previewBox.InitialImage = global::L2Ninja.Properties.Resources.pictureboxplaceholder;
            this.previewBox.Location = new System.Drawing.Point(316, 159);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(512, 384);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 2;
            this.previewBox.TabStop = false;
            this.previewBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.previewBox_DragEnter);
            // 
            // replaceBtn
            // 
            this.replaceBtn.Location = new System.Drawing.Point(316, 567);
            this.replaceBtn.Name = "replaceBtn";
            this.replaceBtn.Size = new System.Drawing.Size(97, 31);
            this.replaceBtn.TabIndex = 1;
            this.replaceBtn.Text = "Replace";
            this.replaceBtn.UseSelectable = true;
            this.replaceBtn.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(419, 567);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(97, 31);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Convert";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // BMPToolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(859, 622);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.replaceBtn);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.loadFileBtn);
            this.Controls.Add(this.filePathText);
            this.MaximizeBox = false;
            this.Name = "BMPToolPanel";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Splash Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox filePathText;
        private MetroFramework.Controls.MetroButton loadFileBtn;
        private System.Windows.Forms.PictureBox previewBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel stateLabel;
        private MetroFramework.Controls.MetroButton decryptBtn;
        private MetroFramework.Controls.MetroButton encryptBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton replaceBtn;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}