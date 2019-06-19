namespace CharacterRecognizer
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxPresetNeuralNetwork = new System.Windows.Forms.TextBox();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCharacters = new System.Windows.Forms.NumericUpDown();
            this.textBoxSelectedCharacterInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPresetRecognition = new System.Windows.Forms.TextBox();
            this.textBoxDataSetStatistics = new System.Windows.Forms.TextBox();
            this.buttonLoadImageFromFile = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.radioButtonTestSet = new System.Windows.Forms.RadioButton();
            this.radioButtonTrainingSet = new System.Windows.Forms.RadioButton();
            this.radioButtonAllData = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxPresetNN = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxCustomNN = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownLearningRateEta = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCustomRecognition = new System.Windows.Forms.TextBox();
            this.buttonTrainCustomNetwork = new System.Windows.Forms.Button();
            this.buttonCreateCustomNetwork = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownOutputLayerSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHiddenLayerSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInputLayerSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCustomNeuralNetwork = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.groupBoxPresetNN.SuspendLayout();
            this.groupBoxCustomNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRateEta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLayerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenLayerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputLayerSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(186, 397);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(158, 158);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // textBoxPresetNeuralNetwork
            // 
            this.textBoxPresetNeuralNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPresetNeuralNetwork.Location = new System.Drawing.Point(6, 45);
            this.textBoxPresetNeuralNetwork.Multiline = true;
            this.textBoxPresetNeuralNetwork.Name = "textBoxPresetNeuralNetwork";
            this.textBoxPresetNeuralNetwork.ReadOnly = true;
            this.textBoxPresetNeuralNetwork.Size = new System.Drawing.Size(337, 110);
            this.textBoxPresetNeuralNetwork.TabIndex = 18;
            this.textBoxPresetNeuralNetwork.Text = "Preset Neural Network:\r\nNot created.";
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(14, 241);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(145, 21);
            this.comboBoxFonts.TabIndex = 19;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select Font";
            // 
            // numericUpDownCharacters
            // 
            this.numericUpDownCharacters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownCharacters.Location = new System.Drawing.Point(191, 242);
            this.numericUpDownCharacters.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCharacters.Name = "numericUpDownCharacters";
            this.numericUpDownCharacters.Size = new System.Drawing.Size(145, 20);
            this.numericUpDownCharacters.TabIndex = 20;
            this.numericUpDownCharacters.ValueChanged += new System.EventHandler(this.numericUpDownCharacters_ValueChanged);
            // 
            // textBoxSelectedCharacterInfo
            // 
            this.textBoxSelectedCharacterInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSelectedCharacterInfo.Location = new System.Drawing.Point(6, 397);
            this.textBoxSelectedCharacterInfo.Multiline = true;
            this.textBoxSelectedCharacterInfo.Name = "textBoxSelectedCharacterInfo";
            this.textBoxSelectedCharacterInfo.ReadOnly = true;
            this.textBoxSelectedCharacterInfo.Size = new System.Drawing.Size(174, 158);
            this.textBoxSelectedCharacterInfo.TabIndex = 21;
            this.textBoxSelectedCharacterInfo.TabStop = false;
            this.textBoxSelectedCharacterInfo.Text = "Loading...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(188, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select Character";
            // 
            // textBoxPresetRecognition
            // 
            this.textBoxPresetRecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPresetRecognition.Location = new System.Drawing.Point(6, 397);
            this.textBoxPresetRecognition.Multiline = true;
            this.textBoxPresetRecognition.Name = "textBoxPresetRecognition";
            this.textBoxPresetRecognition.ReadOnly = true;
            this.textBoxPresetRecognition.Size = new System.Drawing.Size(337, 158);
            this.textBoxPresetRecognition.TabIndex = 22;
            this.textBoxPresetRecognition.Text = "Loading...";
            // 
            // textBoxDataSetStatistics
            // 
            this.textBoxDataSetStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDataSetStatistics.Location = new System.Drawing.Point(6, 43);
            this.textBoxDataSetStatistics.Multiline = true;
            this.textBoxDataSetStatistics.Name = "textBoxDataSetStatistics";
            this.textBoxDataSetStatistics.ReadOnly = true;
            this.textBoxDataSetStatistics.Size = new System.Drawing.Size(338, 112);
            this.textBoxDataSetStatistics.TabIndex = 27;
            this.textBoxDataSetStatistics.TabStop = false;
            this.textBoxDataSetStatistics.Text = "Loading...";
            // 
            // buttonLoadImageFromFile
            // 
            this.buttonLoadImageFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoadImageFromFile.Location = new System.Drawing.Point(84, 312);
            this.buttonLoadImageFromFile.Name = "buttonLoadImageFromFile";
            this.buttonLoadImageFromFile.Size = new System.Drawing.Size(183, 33);
            this.buttonLoadImageFromFile.TabIndex = 28;
            this.buttonLoadImageFromFile.Text = "Select .bmp";
            this.buttonLoadImageFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadImageFromFile.Click += new System.EventHandler(this.buttonLoadImageFromFile_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.radioButtonTestSet);
            this.groupBoxData.Controls.Add(this.radioButtonTrainingSet);
            this.groupBoxData.Controls.Add(this.radioButtonAllData);
            this.groupBoxData.Controls.Add(this.label9);
            this.groupBoxData.Controls.Add(this.label7);
            this.groupBoxData.Controls.Add(this.label8);
            this.groupBoxData.Controls.Add(this.buttonLoadImageFromFile);
            this.groupBoxData.Controls.Add(this.label4);
            this.groupBoxData.Controls.Add(this.label3);
            this.groupBoxData.Controls.Add(this.label1);
            this.groupBoxData.Controls.Add(this.textBoxDataSetStatistics);
            this.groupBoxData.Controls.Add(this.numericUpDownCharacters);
            this.groupBoxData.Controls.Add(this.pictureBox);
            this.groupBoxData.Controls.Add(this.textBoxSelectedCharacterInfo);
            this.groupBoxData.Controls.Add(this.comboBoxFonts);
            this.groupBoxData.Controls.Add(this.label2);
            this.groupBoxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxData.Location = new System.Drawing.Point(9, 6);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(350, 563);
            this.groupBoxData.TabIndex = 29;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // radioButtonTestSet
            // 
            this.radioButtonTestSet.AutoSize = true;
            this.radioButtonTestSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonTestSet.Location = new System.Drawing.Point(270, 204);
            this.radioButtonTestSet.Name = "radioButtonTestSet";
            this.radioButtonTestSet.Size = new System.Drawing.Size(65, 17);
            this.radioButtonTestSet.TabIndex = 38;
            this.radioButtonTestSet.Text = "Test Set";
            this.radioButtonTestSet.UseVisualStyleBackColor = true;
            this.radioButtonTestSet.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTrainingSet
            // 
            this.radioButtonTrainingSet.AutoSize = true;
            this.radioButtonTrainingSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonTrainingSet.Location = new System.Drawing.Point(132, 204);
            this.radioButtonTrainingSet.Name = "radioButtonTrainingSet";
            this.radioButtonTrainingSet.Size = new System.Drawing.Size(82, 17);
            this.radioButtonTrainingSet.TabIndex = 37;
            this.radioButtonTrainingSet.Text = "Training Set";
            this.radioButtonTrainingSet.UseVisualStyleBackColor = true;
            this.radioButtonTrainingSet.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonAllData
            // 
            this.radioButtonAllData.AutoSize = true;
            this.radioButtonAllData.Checked = true;
            this.radioButtonAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonAllData.Location = new System.Drawing.Point(14, 204);
            this.radioButtonAllData.Name = "radioButtonAllData";
            this.radioButtonAllData.Size = new System.Drawing.Size(62, 17);
            this.radioButtonAllData.TabIndex = 36;
            this.radioButtonAllData.TabStop = true;
            this.radioButtonAllData.Text = "All Data";
            this.radioButtonAllData.UseVisualStyleBackColor = true;
            this.radioButtonAllData.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(47, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "(First character of filename will be considered the label)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(105, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Selected Character";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(99, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Load image from file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(115, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Browse dataset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(138, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Statistics";
            // 
            // groupBoxPresetNN
            // 
            this.groupBoxPresetNN.Controls.Add(this.label13);
            this.groupBoxPresetNN.Controls.Add(this.label5);
            this.groupBoxPresetNN.Controls.Add(this.textBoxPresetRecognition);
            this.groupBoxPresetNN.Controls.Add(this.textBoxPresetNeuralNetwork);
            this.groupBoxPresetNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxPresetNN.Location = new System.Drawing.Point(365, 6);
            this.groupBoxPresetNN.Name = "groupBoxPresetNN";
            this.groupBoxPresetNN.Size = new System.Drawing.Size(350, 563);
            this.groupBoxPresetNN.TabIndex = 30;
            this.groupBoxPresetNN.TabStop = false;
            this.groupBoxPresetNN.Text = "Preset Neural Network";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(131, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Recognition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(156, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Info";
            // 
            // groupBoxCustomNN
            // 
            this.groupBoxCustomNN.Controls.Add(this.label17);
            this.groupBoxCustomNN.Controls.Add(this.label16);
            this.groupBoxCustomNN.Controls.Add(this.label15);
            this.groupBoxCustomNN.Controls.Add(this.numericUpDownLearningRateEta);
            this.groupBoxCustomNN.Controls.Add(this.label14);
            this.groupBoxCustomNN.Controls.Add(this.textBoxCustomRecognition);
            this.groupBoxCustomNN.Controls.Add(this.buttonTrainCustomNetwork);
            this.groupBoxCustomNN.Controls.Add(this.buttonCreateCustomNetwork);
            this.groupBoxCustomNN.Controls.Add(this.label12);
            this.groupBoxCustomNN.Controls.Add(this.label11);
            this.groupBoxCustomNN.Controls.Add(this.label10);
            this.groupBoxCustomNN.Controls.Add(this.numericUpDownOutputLayerSize);
            this.groupBoxCustomNN.Controls.Add(this.numericUpDownHiddenLayerSize);
            this.groupBoxCustomNN.Controls.Add(this.numericUpDownInputLayerSize);
            this.groupBoxCustomNN.Controls.Add(this.label6);
            this.groupBoxCustomNN.Controls.Add(this.textBoxCustomNeuralNetwork);
            this.groupBoxCustomNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxCustomNN.Location = new System.Drawing.Point(721, 6);
            this.groupBoxCustomNN.Name = "groupBoxCustomNN";
            this.groupBoxCustomNN.Size = new System.Drawing.Size(350, 563);
            this.groupBoxCustomNN.TabIndex = 31;
            this.groupBoxCustomNN.TabStop = false;
            this.groupBoxCustomNN.Text = "Custom Neural Network";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(116, 350);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "(These may take a while)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(115, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 20);
            this.label16.TabIndex = 44;
            this.label16.Text = "Create Network";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(49, 281);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 16);
            this.label15.TabIndex = 43;
            this.label15.Text = "Learning Rate Eta:";
            // 
            // numericUpDownLearningRateEta
            // 
            this.numericUpDownLearningRateEta.DecimalPlaces = 2;
            this.numericUpDownLearningRateEta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownLearningRateEta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownLearningRateEta.Location = new System.Drawing.Point(184, 279);
            this.numericUpDownLearningRateEta.Name = "numericUpDownLearningRateEta";
            this.numericUpDownLearningRateEta.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLearningRateEta.TabIndex = 42;
            this.numericUpDownLearningRateEta.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(131, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "Recognition";
            // 
            // textBoxCustomRecognition
            // 
            this.textBoxCustomRecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCustomRecognition.Location = new System.Drawing.Point(6, 397);
            this.textBoxCustomRecognition.Multiline = true;
            this.textBoxCustomRecognition.Name = "textBoxCustomRecognition";
            this.textBoxCustomRecognition.ReadOnly = true;
            this.textBoxCustomRecognition.Size = new System.Drawing.Size(337, 158);
            this.textBoxCustomRecognition.TabIndex = 32;
            this.textBoxCustomRecognition.Text = "Loading...";
            // 
            // buttonTrainCustomNetwork
            // 
            this.buttonTrainCustomNetwork.Enabled = false;
            this.buttonTrainCustomNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTrainCustomNetwork.Location = new System.Drawing.Point(184, 313);
            this.buttonTrainCustomNetwork.Name = "buttonTrainCustomNetwork";
            this.buttonTrainCustomNetwork.Size = new System.Drawing.Size(147, 33);
            this.buttonTrainCustomNetwork.TabIndex = 41;
            this.buttonTrainCustomNetwork.Text = "Train";
            this.buttonTrainCustomNetwork.UseVisualStyleBackColor = true;
            this.buttonTrainCustomNetwork.Click += new System.EventHandler(this.buttonTrainCustomNetwork_Click);
            // 
            // buttonCreateCustomNetwork
            // 
            this.buttonCreateCustomNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCreateCustomNetwork.Location = new System.Drawing.Point(17, 313);
            this.buttonCreateCustomNetwork.Name = "buttonCreateCustomNetwork";
            this.buttonCreateCustomNetwork.Size = new System.Drawing.Size(147, 33);
            this.buttonCreateCustomNetwork.TabIndex = 40;
            this.buttonCreateCustomNetwork.Text = "Create";
            this.buttonCreateCustomNetwork.UseVisualStyleBackColor = true;
            this.buttonCreateCustomNetwork.Click += new System.EventHandler(this.buttonCreateCustomNetwork_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(49, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 16);
            this.label12.TabIndex = 39;
            this.label12.Text = "Output Layer Size:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(49, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Hidden Layer Size:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(49, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Input  Layer Size:";
            // 
            // numericUpDownOutputLayerSize
            // 
            this.numericUpDownOutputLayerSize.Enabled = false;
            this.numericUpDownOutputLayerSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownOutputLayerSize.Location = new System.Drawing.Point(184, 251);
            this.numericUpDownOutputLayerSize.Name = "numericUpDownOutputLayerSize";
            this.numericUpDownOutputLayerSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownOutputLayerSize.TabIndex = 36;
            this.numericUpDownOutputLayerSize.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            // 
            // numericUpDownHiddenLayerSize
            // 
            this.numericUpDownHiddenLayerSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownHiddenLayerSize.Location = new System.Drawing.Point(184, 223);
            this.numericUpDownHiddenLayerSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHiddenLayerSize.Name = "numericUpDownHiddenLayerSize";
            this.numericUpDownHiddenLayerSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownHiddenLayerSize.TabIndex = 35;
            this.numericUpDownHiddenLayerSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownInputLayerSize
            // 
            this.numericUpDownInputLayerSize.Enabled = false;
            this.numericUpDownInputLayerSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownInputLayerSize.Location = new System.Drawing.Point(184, 195);
            this.numericUpDownInputLayerSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInputLayerSize.Name = "numericUpDownInputLayerSize";
            this.numericUpDownInputLayerSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownInputLayerSize.TabIndex = 34;
            this.numericUpDownInputLayerSize.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(156, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Info";
            // 
            // textBoxCustomNeuralNetwork
            // 
            this.textBoxCustomNeuralNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCustomNeuralNetwork.Location = new System.Drawing.Point(6, 46);
            this.textBoxCustomNeuralNetwork.Multiline = true;
            this.textBoxCustomNeuralNetwork.Name = "textBoxCustomNeuralNetwork";
            this.textBoxCustomNeuralNetwork.ReadOnly = true;
            this.textBoxCustomNeuralNetwork.Size = new System.Drawing.Size(337, 109);
            this.textBoxCustomNeuralNetwork.TabIndex = 32;
            this.textBoxCustomNeuralNetwork.Text = "Custom Neural Network:\r\nNot created.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 574);
            this.Controls.Add(this.groupBoxCustomNN);
            this.Controls.Add(this.groupBoxPresetNN);
            this.Controls.Add(this.groupBoxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "CharacterRecognizer";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxPresetNN.ResumeLayout(false);
            this.groupBoxPresetNN.PerformLayout();
            this.groupBoxCustomNN.ResumeLayout(false);
            this.groupBoxCustomNN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRateEta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLayerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenLayerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputLayerSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxPresetNeuralNetwork;
        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCharacters;
        private System.Windows.Forms.TextBox textBoxSelectedCharacterInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPresetRecognition;
        private System.Windows.Forms.TextBox textBoxDataSetStatistics;
        private System.Windows.Forms.Button buttonLoadImageFromFile;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.GroupBox groupBoxPresetNN;
        private System.Windows.Forms.GroupBox groupBoxCustomNN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCustomNeuralNetwork;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputLayerSize;
        private System.Windows.Forms.NumericUpDown numericUpDownHiddenLayerSize;
        private System.Windows.Forms.NumericUpDown numericUpDownInputLayerSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownLearningRateEta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCustomRecognition;
        private System.Windows.Forms.Button buttonTrainCustomNetwork;
        private System.Windows.Forms.Button buttonCreateCustomNetwork;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButtonTestSet;
        private System.Windows.Forms.RadioButton radioButtonTrainingSet;
        private System.Windows.Forms.RadioButton radioButtonAllData;
        private System.Windows.Forms.Label label17;
    }
}

