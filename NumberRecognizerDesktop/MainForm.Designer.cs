namespace NumberRecognizerDesktop
{
    partial class MainForm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBoxTests = new System.Windows.Forms.TextBox();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCharacters = new System.Windows.Forms.NumericUpDown();
            this.textBoxSelectedCharacterInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(74, 366);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 56);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(297, 366);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(224, 224);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(156, 366);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(112, 112);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // textBoxTests
            // 
            this.textBoxTests.Location = new System.Drawing.Point(312, 12);
            this.textBoxTests.Multiline = true;
            this.textBoxTests.Name = "textBoxTests";
            this.textBoxTests.ReadOnly = true;
            this.textBoxTests.Size = new System.Drawing.Size(502, 212);
            this.textBoxTests.TabIndex = 18;
            this.textBoxTests.Text = "Nothing yet.";
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(15, 263);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFonts.TabIndex = 19;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.SelectedCharacterChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select Font";
            // 
            // numericUpDownCharacters
            // 
            this.numericUpDownCharacters.Location = new System.Drawing.Point(16, 309);
            this.numericUpDownCharacters.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCharacters.Name = "numericUpDownCharacters";
            this.numericUpDownCharacters.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCharacters.TabIndex = 20;
            this.numericUpDownCharacters.ValueChanged += new System.EventHandler(this.SelectedCharacterChanged);
            // 
            // textBoxSelectedCharacterInfo
            // 
            this.textBoxSelectedCharacterInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxSelectedCharacterInfo.Multiline = true;
            this.textBoxSelectedCharacterInfo.Name = "textBoxSelectedCharacterInfo";
            this.textBoxSelectedCharacterInfo.ReadOnly = true;
            this.textBoxSelectedCharacterInfo.Size = new System.Drawing.Size(294, 212);
            this.textBoxSelectedCharacterInfo.TabIndex = 21;
            this.textBoxSelectedCharacterInfo.Text = "Nothing yet.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select Character";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 602);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSelectedCharacterInfo);
            this.Controls.Add(this.numericUpDownCharacters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFonts);
            this.Controls.Add(this.textBoxTests);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBoxTests;
        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCharacters;
        private System.Windows.Forms.TextBox textBoxSelectedCharacterInfo;
        private System.Windows.Forms.Label label2;
    }
}

