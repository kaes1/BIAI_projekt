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
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonDisplayUCI = new System.Windows.Forms.Button();
            this.numericUpDownSelectMNIST = new System.Windows.Forms.NumericUpDown();
            this.buttonDisplayMNIST = new System.Windows.Forms.Button();
            this.groupBoxUCI = new System.Windows.Forms.GroupBox();
            this.labelSelectCharacter = new System.Windows.Forms.Label();
            this.labelSelectFont = new System.Windows.Forms.Label();
            this.numericUpDownSelectCharacter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSelectFont = new System.Windows.Forms.NumericUpDown();
            this.textBoxTests = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectMNIST)).BeginInit();
            this.groupBoxUCI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectFont)).BeginInit();
            this.SuspendLayout();
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(200, 21);
            this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(131, 26);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Hello World!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(74, 366);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 56);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxMain
            // 
            this.textBoxMain.Location = new System.Drawing.Point(12, 66);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ReadOnly = true;
            this.textBoxMain.Size = new System.Drawing.Size(177, 120);
            this.textBoxMain.TabIndex = 5;
            this.textBoxMain.Text = "Nothing yet.";
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
            // buttonDisplayUCI
            // 
            this.buttonDisplayUCI.Location = new System.Drawing.Point(18, 127);
            this.buttonDisplayUCI.Name = "buttonDisplayUCI";
            this.buttonDisplayUCI.Size = new System.Drawing.Size(100, 29);
            this.buttonDisplayUCI.TabIndex = 14;
            this.buttonDisplayUCI.Text = "Display UCI";
            this.buttonDisplayUCI.UseVisualStyleBackColor = true;
            this.buttonDisplayUCI.Click += new System.EventHandler(this.buttonDisplayUCI_Click);
            // 
            // numericUpDownSelectMNIST
            // 
            this.numericUpDownSelectMNIST.Location = new System.Drawing.Point(305, 321);
            this.numericUpDownSelectMNIST.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSelectMNIST.Name = "numericUpDownSelectMNIST";
            this.numericUpDownSelectMNIST.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownSelectMNIST.TabIndex = 15;
            // 
            // buttonDisplayMNIST
            // 
            this.buttonDisplayMNIST.Location = new System.Drawing.Point(302, 286);
            this.buttonDisplayMNIST.Name = "buttonDisplayMNIST";
            this.buttonDisplayMNIST.Size = new System.Drawing.Size(100, 29);
            this.buttonDisplayMNIST.TabIndex = 16;
            this.buttonDisplayMNIST.Text = "Display MNIST";
            this.buttonDisplayMNIST.UseVisualStyleBackColor = true;
            this.buttonDisplayMNIST.Click += new System.EventHandler(this.buttonDisplayMNIST_Click);
            // 
            // groupBoxUCI
            // 
            this.groupBoxUCI.Controls.Add(this.labelSelectCharacter);
            this.groupBoxUCI.Controls.Add(this.labelSelectFont);
            this.groupBoxUCI.Controls.Add(this.numericUpDownSelectCharacter);
            this.groupBoxUCI.Controls.Add(this.buttonDisplayUCI);
            this.groupBoxUCI.Controls.Add(this.numericUpDownSelectFont);
            this.groupBoxUCI.Location = new System.Drawing.Point(12, 192);
            this.groupBoxUCI.Name = "groupBoxUCI";
            this.groupBoxUCI.Size = new System.Drawing.Size(136, 168);
            this.groupBoxUCI.TabIndex = 17;
            this.groupBoxUCI.TabStop = false;
            this.groupBoxUCI.Text = "UCI";
            // 
            // labelSelectCharacter
            // 
            this.labelSelectCharacter.AutoSize = true;
            this.labelSelectCharacter.Location = new System.Drawing.Point(15, 73);
            this.labelSelectCharacter.Name = "labelSelectCharacter";
            this.labelSelectCharacter.Size = new System.Drawing.Size(86, 13);
            this.labelSelectCharacter.TabIndex = 3;
            this.labelSelectCharacter.Text = "Select Character";
            // 
            // labelSelectFont
            // 
            this.labelSelectFont.AutoSize = true;
            this.labelSelectFont.Location = new System.Drawing.Point(15, 25);
            this.labelSelectFont.Name = "labelSelectFont";
            this.labelSelectFont.Size = new System.Drawing.Size(61, 13);
            this.labelSelectFont.TabIndex = 2;
            this.labelSelectFont.Text = "Select Font";
            // 
            // numericUpDownSelectCharacter
            // 
            this.numericUpDownSelectCharacter.Location = new System.Drawing.Point(18, 89);
            this.numericUpDownSelectCharacter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSelectCharacter.Name = "numericUpDownSelectCharacter";
            this.numericUpDownSelectCharacter.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownSelectCharacter.TabIndex = 1;
            // 
            // numericUpDownSelectFont
            // 
            this.numericUpDownSelectFont.Location = new System.Drawing.Point(18, 41);
            this.numericUpDownSelectFont.Maximum = new decimal(new int[] {
            152,
            0,
            0,
            0});
            this.numericUpDownSelectFont.Name = "numericUpDownSelectFont";
            this.numericUpDownSelectFont.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownSelectFont.TabIndex = 0;
            this.numericUpDownSelectFont.ValueChanged += new System.EventHandler(this.numericUpDownSelectFont_ValueChanged);
            // 
            // textBoxTests
            // 
            this.textBoxTests.Location = new System.Drawing.Point(195, 66);
            this.textBoxTests.Multiline = true;
            this.textBoxTests.Name = "textBoxTests";
            this.textBoxTests.ReadOnly = true;
            this.textBoxTests.Size = new System.Drawing.Size(326, 212);
            this.textBoxTests.TabIndex = 18;
            this.textBoxTests.Text = "Nothing yet.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 602);
            this.Controls.Add(this.textBoxTests);
            this.Controls.Add(this.groupBoxUCI);
            this.Controls.Add(this.buttonDisplayMNIST);
            this.Controls.Add(this.numericUpDownSelectMNIST);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.helloWorldLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectMNIST)).EndInit();
            this.groupBoxUCI.ResumeLayout(false);
            this.groupBoxUCI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectFont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonDisplayUCI;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectMNIST;
        private System.Windows.Forms.Button buttonDisplayMNIST;
        private System.Windows.Forms.GroupBox groupBoxUCI;
        private System.Windows.Forms.Label labelSelectCharacter;
        private System.Windows.Forms.Label labelSelectFont;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectCharacter;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectFont;
        private System.Windows.Forms.TextBox textBoxTests;
    }
}

