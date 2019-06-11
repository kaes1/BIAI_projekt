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
            this.pictureBoxData = new System.Windows.Forms.PictureBox();
            this.textBoxTests = new System.Windows.Forms.TextBox();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCharacters = new System.Windows.Forms.NumericUpDown();
            this.textBoxSelectedCharacterInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRecognized = new System.Windows.Forms.TextBox();
            this.pictureBoxRecognize = new System.Windows.Forms.PictureBox();
            this.textBoxDataSetStatistics = new System.Windows.Forms.TextBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBoxBrowseData = new System.Windows.Forms.GroupBox();
            this.buttonRecognizeFromData = new System.Windows.Forms.Button();
            this.groupBoxRecognize = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoRecognize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecognize)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.groupBoxBrowseData.SuspendLayout();
            this.groupBoxRecognize.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxData
            // 
            this.pictureBoxData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxData.Location = new System.Drawing.Point(166, 27);
            this.pictureBoxData.Name = "pictureBoxData";
            this.pictureBoxData.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxData.TabIndex = 7;
            this.pictureBoxData.TabStop = false;
            // 
            // textBoxTests
            // 
            this.textBoxTests.Location = new System.Drawing.Point(6, 19);
            this.textBoxTests.Multiline = true;
            this.textBoxTests.Name = "textBoxTests";
            this.textBoxTests.ReadOnly = true;
            this.textBoxTests.Size = new System.Drawing.Size(399, 201);
            this.textBoxTests.TabIndex = 18;
            this.textBoxTests.Text = "Nothing yet.";
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(25, 42);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFonts.TabIndex = 19;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select Font";
            // 
            // numericUpDownCharacters
            // 
            this.numericUpDownCharacters.Location = new System.Drawing.Point(25, 81);
            this.numericUpDownCharacters.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCharacters.Name = "numericUpDownCharacters";
            this.numericUpDownCharacters.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCharacters.TabIndex = 20;
            this.numericUpDownCharacters.ValueChanged += new System.EventHandler(this.numericUpDownCharacters_ValueChanged);
            // 
            // textBoxSelectedCharacterInfo
            // 
            this.textBoxSelectedCharacterInfo.Location = new System.Drawing.Point(10, 200);
            this.textBoxSelectedCharacterInfo.Multiline = true;
            this.textBoxSelectedCharacterInfo.Name = "textBoxSelectedCharacterInfo";
            this.textBoxSelectedCharacterInfo.ReadOnly = true;
            this.textBoxSelectedCharacterInfo.Size = new System.Drawing.Size(316, 149);
            this.textBoxSelectedCharacterInfo.TabIndex = 21;
            this.textBoxSelectedCharacterInfo.TabStop = false;
            this.textBoxSelectedCharacterInfo.Text = "Character information.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select Character";
            // 
            // textBoxRecognized
            // 
            this.textBoxRecognized.Location = new System.Drawing.Point(6, 253);
            this.textBoxRecognized.Multiline = true;
            this.textBoxRecognized.Name = "textBoxRecognized";
            this.textBoxRecognized.ReadOnly = true;
            this.textBoxRecognized.Size = new System.Drawing.Size(207, 322);
            this.textBoxRecognized.TabIndex = 22;
            this.textBoxRecognized.Text = "Nothing yet.";
            // 
            // pictureBoxRecognize
            // 
            this.pictureBoxRecognize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRecognize.Location = new System.Drawing.Point(245, 252);
            this.pictureBoxRecognize.Name = "pictureBoxRecognize";
            this.pictureBoxRecognize.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxRecognize.TabIndex = 24;
            this.pictureBoxRecognize.TabStop = false;
            // 
            // textBoxDataSetStatistics
            // 
            this.textBoxDataSetStatistics.Location = new System.Drawing.Point(6, 19);
            this.textBoxDataSetStatistics.Multiline = true;
            this.textBoxDataSetStatistics.Name = "textBoxDataSetStatistics";
            this.textBoxDataSetStatistics.ReadOnly = true;
            this.textBoxDataSetStatistics.Size = new System.Drawing.Size(337, 201);
            this.textBoxDataSetStatistics.TabIndex = 27;
            this.textBoxDataSetStatistics.TabStop = false;
            this.textBoxDataSetStatistics.Text = "Statistics";
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(245, 469);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(160, 35);
            this.buttonRecognize.TabIndex = 28;
            this.buttonRecognize.Text = "Load Image to Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.groupBoxBrowseData);
            this.groupBoxData.Controls.Add(this.textBoxDataSetStatistics);
            this.groupBoxData.Location = new System.Drawing.Point(12, 12);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(354, 590);
            this.groupBoxData.TabIndex = 29;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // groupBoxBrowseData
            // 
            this.groupBoxBrowseData.Controls.Add(this.checkBoxAutoRecognize);
            this.groupBoxBrowseData.Controls.Add(this.buttonRecognizeFromData);
            this.groupBoxBrowseData.Controls.Add(this.label1);
            this.groupBoxBrowseData.Controls.Add(this.numericUpDownCharacters);
            this.groupBoxBrowseData.Controls.Add(this.textBoxSelectedCharacterInfo);
            this.groupBoxBrowseData.Controls.Add(this.label2);
            this.groupBoxBrowseData.Controls.Add(this.pictureBoxData);
            this.groupBoxBrowseData.Controls.Add(this.comboBoxFonts);
            this.groupBoxBrowseData.Location = new System.Drawing.Point(6, 226);
            this.groupBoxBrowseData.Name = "groupBoxBrowseData";
            this.groupBoxBrowseData.Size = new System.Drawing.Size(337, 358);
            this.groupBoxBrowseData.TabIndex = 28;
            this.groupBoxBrowseData.TabStop = false;
            this.groupBoxBrowseData.Text = "Browse";
            // 
            // buttonRecognizeFromData
            // 
            this.buttonRecognizeFromData.Location = new System.Drawing.Point(25, 128);
            this.buttonRecognizeFromData.Name = "buttonRecognizeFromData";
            this.buttonRecognizeFromData.Size = new System.Drawing.Size(126, 35);
            this.buttonRecognizeFromData.TabIndex = 0;
            this.buttonRecognizeFromData.Text = "Recognize This Image";
            this.buttonRecognizeFromData.UseVisualStyleBackColor = true;
            this.buttonRecognizeFromData.Click += new System.EventHandler(this.buttonRecognizeFromData_Click);
            // 
            // groupBoxRecognize
            // 
            this.groupBoxRecognize.Controls.Add(this.buttonRecognize);
            this.groupBoxRecognize.Controls.Add(this.textBoxRecognized);
            this.groupBoxRecognize.Controls.Add(this.pictureBoxRecognize);
            this.groupBoxRecognize.Controls.Add(this.textBoxTests);
            this.groupBoxRecognize.Location = new System.Drawing.Point(372, 12);
            this.groupBoxRecognize.Name = "groupBoxRecognize";
            this.groupBoxRecognize.Size = new System.Drawing.Size(411, 590);
            this.groupBoxRecognize.TabIndex = 30;
            this.groupBoxRecognize.TabStop = false;
            this.groupBoxRecognize.Text = "Recognize";
            // 
            // checkBoxAutoRecognize
            // 
            this.checkBoxAutoRecognize.AutoSize = true;
            this.checkBoxAutoRecognize.Checked = true;
            this.checkBoxAutoRecognize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoRecognize.Location = new System.Drawing.Point(35, 170);
            this.checkBoxAutoRecognize.Name = "checkBoxAutoRecognize";
            this.checkBoxAutoRecognize.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAutoRecognize.TabIndex = 22;
            this.checkBoxAutoRecognize.Text = "Auto Recognize";
            this.checkBoxAutoRecognize.UseVisualStyleBackColor = true;
            this.checkBoxAutoRecognize.CheckedChanged += new System.EventHandler(this.checkBoxAutoRecognize_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 614);
            this.Controls.Add(this.groupBoxRecognize);
            this.Controls.Add(this.groupBoxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecognize)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxBrowseData.ResumeLayout(false);
            this.groupBoxBrowseData.PerformLayout();
            this.groupBoxRecognize.ResumeLayout(false);
            this.groupBoxRecognize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxData;
        private System.Windows.Forms.TextBox textBoxTests;
        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCharacters;
        private System.Windows.Forms.TextBox textBoxSelectedCharacterInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRecognized;
        private System.Windows.Forms.PictureBox pictureBoxRecognize;
        private System.Windows.Forms.TextBox textBoxDataSetStatistics;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.GroupBox groupBoxRecognize;
        private System.Windows.Forms.GroupBox groupBoxBrowseData;
        private System.Windows.Forms.Button buttonRecognizeFromData;
        private System.Windows.Forms.CheckBox checkBoxAutoRecognize;
    }
}

