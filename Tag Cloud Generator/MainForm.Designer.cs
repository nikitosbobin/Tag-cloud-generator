namespace Tag_Cloud_Generator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textLoadGroup = new System.Windows.Forms.GroupBox();
            this.loadedFilePath = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.browseFileButton = new System.Windows.Forms.Button();
            this.cloudGeneratingGroup = new System.Windows.Forms.GroupBox();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.accuracyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.shouldStemWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.recreateCheckBox = new System.Windows.Forms.CheckBox();
            this.colorsCountLabel = new System.Windows.Forms.Label();
            this.wordsColorsButton = new System.Windows.Forms.Button();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.wordsColorsLabel = new System.Windows.Forms.Label();
            this.backgroundColor = new System.Windows.Forms.PictureBox();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.fontStringLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.fontButton = new System.Windows.Forms.Button();
            this.firstWordScaleLabel = new System.Windows.Forms.Label();
            this.wordsAmountLabel = new System.Windows.Forms.Label();
            this.firstWordScaleBar = new System.Windows.Forms.TrackBar();
            this.wordsAmountBar = new System.Windows.Forms.TrackBar();
            this.imageSizeGroup = new System.Windows.Forms.GroupBox();
            this.templateLabel = new System.Windows.Forms.Label();
            this.templateSelector = new System.Windows.Forms.ComboBox();
            this.imageHeight = new System.Windows.Forms.NumericUpDown();
            this.imageWidth = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.loadTextDialog = new System.Windows.Forms.OpenFileDialog();
            this.cloudImageBox = new System.Windows.Forms.PictureBox();
            this.generateCloudButton = new System.Windows.Forms.Button();
            this.cloudCreatingProgress = new System.Windows.Forms.ProgressBar();
            this.programStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.programStatusStrip = new System.Windows.Forms.StatusStrip();
            this.wordsColorDialog = new System.Windows.Forms.ColorDialog();
            this.wordsFontDialog = new System.Windows.Forms.FontDialog();
            this.backgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundCloudCreator = new System.ComponentModel.BackgroundWorker();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancelCreatingButton = new System.Windows.Forms.Button();
            this.textLoadGroup.SuspendLayout();
            this.cloudGeneratingGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstWordScaleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsAmountBar)).BeginInit();
            this.imageSizeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudImageBox)).BeginInit();
            this.programStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textLoadGroup
            // 
            this.textLoadGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLoadGroup.Controls.Add(this.loadedFilePath);
            this.textLoadGroup.Controls.Add(this.fileLabel);
            this.textLoadGroup.Controls.Add(this.browseFileButton);
            this.textLoadGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textLoadGroup.Location = new System.Drawing.Point(14, 14);
            this.textLoadGroup.Name = "textLoadGroup";
            this.textLoadGroup.Size = new System.Drawing.Size(475, 72);
            this.textLoadGroup.TabIndex = 0;
            this.textLoadGroup.TabStop = false;
            this.textLoadGroup.Text = "Text load";
            // 
            // loadedFilePath
            // 
            this.loadedFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadedFilePath.Location = new System.Drawing.Point(49, 29);
            this.loadedFilePath.Name = "loadedFilePath";
            this.loadedFilePath.ReadOnly = true;
            this.loadedFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loadedFilePath.Size = new System.Drawing.Size(324, 23);
            this.loadedFilePath.TabIndex = 2;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(7, 31);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(30, 15);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "File:";
            // 
            // browseFileButton
            // 
            this.browseFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseFileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.browseFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.browseFileButton.Location = new System.Drawing.Point(380, 28);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(87, 25);
            this.browseFileButton.TabIndex = 0;
            this.browseFileButton.Text = "Browse...";
            this.browseFileButton.UseVisualStyleBackColor = false;
            this.browseFileButton.Click += new System.EventHandler(this.browseFileButton_Click);
            // 
            // cloudGeneratingGroup
            // 
            this.cloudGeneratingGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cloudGeneratingGroup.Controls.Add(this.accuracyLabel);
            this.cloudGeneratingGroup.Controls.Add(this.accuracyNumericUpDown);
            this.cloudGeneratingGroup.Controls.Add(this.shouldStemWordsCheckBox);
            this.cloudGeneratingGroup.Controls.Add(this.recreateCheckBox);
            this.cloudGeneratingGroup.Controls.Add(this.colorsCountLabel);
            this.cloudGeneratingGroup.Controls.Add(this.wordsColorsButton);
            this.cloudGeneratingGroup.Controls.Add(this.saveImageButton);
            this.cloudGeneratingGroup.Controls.Add(this.wordsColorsLabel);
            this.cloudGeneratingGroup.Controls.Add(this.backgroundColor);
            this.cloudGeneratingGroup.Controls.Add(this.backgroundLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontStringLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontButton);
            this.cloudGeneratingGroup.Controls.Add(this.firstWordScaleLabel);
            this.cloudGeneratingGroup.Controls.Add(this.wordsAmountLabel);
            this.cloudGeneratingGroup.Controls.Add(this.firstWordScaleBar);
            this.cloudGeneratingGroup.Controls.Add(this.wordsAmountBar);
            this.cloudGeneratingGroup.Enabled = false;
            this.cloudGeneratingGroup.Location = new System.Drawing.Point(507, 135);
            this.cloudGeneratingGroup.Name = "cloudGeneratingGroup";
            this.cloudGeneratingGroup.Size = new System.Drawing.Size(332, 370);
            this.cloudGeneratingGroup.TabIndex = 1;
            this.cloudGeneratingGroup.TabStop = false;
            this.cloudGeneratingGroup.Text = "Cloud generating";
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(3, 145);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(56, 15);
            this.accuracyLabel.TabIndex = 15;
            this.accuracyLabel.Text = "Accuracy";
            // 
            // accuracyNumericUpDown
            // 
            this.accuracyNumericUpDown.Location = new System.Drawing.Point(223, 143);
            this.accuracyNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.accuracyNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.accuracyNumericUpDown.Name = "accuracyNumericUpDown";
            this.accuracyNumericUpDown.Size = new System.Drawing.Size(87, 23);
            this.accuracyNumericUpDown.TabIndex = 6;
            this.accuracyNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.accuracyNumericUpDown.ValueChanged += new System.EventHandler(this.accuracyNumericUpDown_ValueChanged);
            // 
            // shouldStemWordsCheckBox
            // 
            this.shouldStemWordsCheckBox.AutoSize = true;
            this.shouldStemWordsCheckBox.Checked = true;
            this.shouldStemWordsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shouldStemWordsCheckBox.Location = new System.Drawing.Point(6, 113);
            this.shouldStemWordsCheckBox.Name = "shouldStemWordsCheckBox";
            this.shouldStemWordsCheckBox.Size = new System.Drawing.Size(188, 19);
            this.shouldStemWordsCheckBox.TabIndex = 14;
            this.shouldStemWordsCheckBox.Text = "Quote words in the initial form";
            this.shouldStemWordsCheckBox.UseVisualStyleBackColor = true;
            this.shouldStemWordsCheckBox.CheckedChanged += new System.EventHandler(this.shouldStemWordsCheckBox_CheckedChanged);
            // 
            // recreateCheckBox
            // 
            this.recreateCheckBox.AutoSize = true;
            this.recreateCheckBox.Location = new System.Drawing.Point(6, 300);
            this.recreateCheckBox.Name = "recreateCheckBox";
            this.recreateCheckBox.Size = new System.Drawing.Size(159, 19);
            this.recreateCheckBox.TabIndex = 13;
            this.recreateCheckBox.Text = "Recreate cloud everytime";
            this.recreateCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorsCountLabel
            // 
            this.colorsCountLabel.AutoSize = true;
            this.colorsCountLabel.Location = new System.Drawing.Point(88, 225);
            this.colorsCountLabel.Name = "colorsCountLabel";
            this.colorsCountLabel.Size = new System.Drawing.Size(13, 15);
            this.colorsCountLabel.TabIndex = 8;
            this.colorsCountLabel.Text = "0";
            // 
            // wordsColorsButton
            // 
            this.wordsColorsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.wordsColorsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wordsColorsButton.Location = new System.Drawing.Point(223, 219);
            this.wordsColorsButton.Name = "wordsColorsButton";
            this.wordsColorsButton.Size = new System.Drawing.Size(87, 27);
            this.wordsColorsButton.TabIndex = 11;
            this.wordsColorsButton.Text = "Change";
            this.wordsColorsButton.UseVisualStyleBackColor = false;
            this.wordsColorsButton.Click += new System.EventHandler(this.wordsColorsButton_Click);
            // 
            // saveImageButton
            // 
            this.saveImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveImageButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.saveImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveImageButton.Enabled = false;
            this.saveImageButton.Location = new System.Drawing.Point(223, 324);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(87, 27);
            this.saveImageButton.TabIndex = 5;
            this.saveImageButton.Text = "Save as";
            this.saveImageButton.UseVisualStyleBackColor = false;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // wordsColorsLabel
            // 
            this.wordsColorsLabel.AutoSize = true;
            this.wordsColorsLabel.Location = new System.Drawing.Point(3, 225);
            this.wordsColorsLabel.Name = "wordsColorsLabel";
            this.wordsColorsLabel.Size = new System.Drawing.Size(79, 15);
            this.wordsColorsLabel.TabIndex = 10;
            this.wordsColorsLabel.Text = "Words colors:";
            // 
            // backgroundColor
            // 
            this.backgroundColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backgroundColor.Location = new System.Drawing.Point(91, 257);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(83, 25);
            this.backgroundColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backgroundColor.TabIndex = 9;
            this.backgroundColor.TabStop = false;
            this.backgroundColor.Click += new System.EventHandler(this.backgroundColor_Click);
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Location = new System.Drawing.Point(3, 261);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(74, 15);
            this.backgroundLabel.TabIndex = 7;
            this.backgroundLabel.Text = "Background:";
            // 
            // fontStringLabel
            // 
            this.fontStringLabel.AutoSize = true;
            this.fontStringLabel.Location = new System.Drawing.Point(56, 184);
            this.fontStringLabel.Name = "fontStringLabel";
            this.fontStringLabel.Size = new System.Drawing.Size(53, 15);
            this.fontStringLabel.TabIndex = 6;
            this.fontStringLabel.Text = "Segoe UI";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(3, 184);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(37, 15);
            this.fontLabel.TabIndex = 5;
            this.fontLabel.Text = "Font: ";
            // 
            // fontButton
            // 
            this.fontButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fontButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fontButton.Location = new System.Drawing.Point(223, 178);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(87, 27);
            this.fontButton.TabIndex = 4;
            this.fontButton.Text = "Change";
            this.fontButton.UseVisualStyleBackColor = false;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // firstWordScaleLabel
            // 
            this.firstWordScaleLabel.AutoSize = true;
            this.firstWordScaleLabel.Location = new System.Drawing.Point(223, 31);
            this.firstWordScaleLabel.MaximumSize = new System.Drawing.Size(157, 58);
            this.firstWordScaleLabel.Name = "firstWordScaleLabel";
            this.firstWordScaleLabel.Size = new System.Drawing.Size(34, 15);
            this.firstWordScaleLabel.TabIndex = 3;
            this.firstWordScaleLabel.Text = "Scale";
            // 
            // wordsAmountLabel
            // 
            this.wordsAmountLabel.AutoSize = true;
            this.wordsAmountLabel.Location = new System.Drawing.Point(40, 33);
            this.wordsAmountLabel.Name = "wordsAmountLabel";
            this.wordsAmountLabel.Size = new System.Drawing.Size(86, 15);
            this.wordsAmountLabel.TabIndex = 2;
            this.wordsAmountLabel.Text = "Words amount";
            // 
            // firstWordScaleBar
            // 
            this.firstWordScaleBar.Location = new System.Drawing.Point(168, 65);
            this.firstWordScaleBar.Minimum = 1;
            this.firstWordScaleBar.Name = "firstWordScaleBar";
            this.firstWordScaleBar.Size = new System.Drawing.Size(150, 45);
            this.firstWordScaleBar.TabIndex = 1;
            this.firstWordScaleBar.Value = 10;
            this.firstWordScaleBar.Scroll += new System.EventHandler(this.firstWordScaleBar_Scroll);
            // 
            // wordsAmountBar
            // 
            this.wordsAmountBar.Location = new System.Drawing.Point(7, 65);
            this.wordsAmountBar.Maximum = 100;
            this.wordsAmountBar.Name = "wordsAmountBar";
            this.wordsAmountBar.Size = new System.Drawing.Size(154, 45);
            this.wordsAmountBar.TabIndex = 0;
            this.wordsAmountBar.TickFrequency = 10;
            this.wordsAmountBar.Value = 50;
            this.wordsAmountBar.Scroll += new System.EventHandler(this.wordsAmountBar_Scroll);
            // 
            // imageSizeGroup
            // 
            this.imageSizeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSizeGroup.Controls.Add(this.templateLabel);
            this.imageSizeGroup.Controls.Add(this.templateSelector);
            this.imageSizeGroup.Controls.Add(this.imageHeight);
            this.imageSizeGroup.Controls.Add(this.imageWidth);
            this.imageSizeGroup.Controls.Add(this.heightLabel);
            this.imageSizeGroup.Controls.Add(this.widthLabel);
            this.imageSizeGroup.Enabled = false;
            this.imageSizeGroup.Location = new System.Drawing.Point(507, 14);
            this.imageSizeGroup.Name = "imageSizeGroup";
            this.imageSizeGroup.Size = new System.Drawing.Size(332, 114);
            this.imageSizeGroup.TabIndex = 2;
            this.imageSizeGroup.TabStop = false;
            this.imageSizeGroup.Text = "Tag cloud size";
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Location = new System.Drawing.Point(3, 33);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(63, 15);
            this.templateLabel.TabIndex = 5;
            this.templateLabel.Text = "Template: ";
            // 
            // templateSelector
            // 
            this.templateSelector.FormattingEnabled = true;
            this.templateSelector.Location = new System.Drawing.Point(75, 28);
            this.templateSelector.Name = "templateSelector";
            this.templateSelector.Size = new System.Drawing.Size(250, 23);
            this.templateSelector.TabIndex = 4;
            this.templateSelector.SelectedIndexChanged += new System.EventHandler(this.templateSelector_SelectedIndexChanged);
            // 
            // imageHeight
            // 
            this.imageHeight.Location = new System.Drawing.Point(240, 68);
            this.imageHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageHeight.Name = "imageHeight";
            this.imageHeight.Size = new System.Drawing.Size(76, 23);
            this.imageHeight.TabIndex = 3;
            this.imageHeight.Value = new decimal(new int[] {
            576,
            0,
            0,
            0});
            this.imageHeight.ValueChanged += new System.EventHandler(this.imageHeight_ValueChanged);
            // 
            // imageWidth
            // 
            this.imageWidth.Location = new System.Drawing.Point(75, 68);
            this.imageWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageWidth.Name = "imageWidth";
            this.imageWidth.Size = new System.Drawing.Size(76, 23);
            this.imageWidth.TabIndex = 2;
            this.imageWidth.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.imageWidth.ValueChanged += new System.EventHandler(this.imageWidth_ValueChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(187, 70);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(49, 15);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height: ";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(20, 70);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(45, 15);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width: ";
            // 
            // loadTextDialog
            // 
            this.loadTextDialog.FileName = "loadTextDialog";
            this.loadTextDialog.Filter = "Text files|*.txt|All files|*.*";
            this.loadTextDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadTextDialog_FileOk);
            // 
            // cloudImageBox
            // 
            this.cloudImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cloudImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cloudImageBox.Location = new System.Drawing.Point(14, 92);
            this.cloudImageBox.Name = "cloudImageBox";
            this.cloudImageBox.Size = new System.Drawing.Size(474, 428);
            this.cloudImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cloudImageBox.TabIndex = 4;
            this.cloudImageBox.TabStop = false;
            // 
            // generateCloudButton
            // 
            this.generateCloudButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateCloudButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generateCloudButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.generateCloudButton.Enabled = false;
            this.generateCloudButton.Location = new System.Drawing.Point(658, 538);
            this.generateCloudButton.Name = "generateCloudButton";
            this.generateCloudButton.Size = new System.Drawing.Size(87, 27);
            this.generateCloudButton.TabIndex = 6;
            this.generateCloudButton.Text = "Generate";
            this.generateCloudButton.UseVisualStyleBackColor = false;
            this.generateCloudButton.Click += new System.EventHandler(this.generateCloudButton_Click);
            // 
            // cloudCreatingProgress
            // 
            this.cloudCreatingProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cloudCreatingProgress.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cloudCreatingProgress.Location = new System.Drawing.Point(13, 538);
            this.cloudCreatingProgress.Name = "cloudCreatingProgress";
            this.cloudCreatingProgress.Size = new System.Drawing.Size(603, 27);
            this.cloudCreatingProgress.TabIndex = 7;
            // 
            // programStatus
            // 
            this.programStatus.Name = "programStatus";
            this.programStatus.Size = new System.Drawing.Size(76, 17);
            this.programStatus.Text = "Text not load";
            // 
            // programStatusStrip
            // 
            this.programStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programStatus});
            this.programStatusStrip.Location = new System.Drawing.Point(0, 589);
            this.programStatusStrip.Name = "programStatusStrip";
            this.programStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.programStatusStrip.Size = new System.Drawing.Size(854, 22);
            this.programStatusStrip.SizingGrip = false;
            this.programStatusStrip.TabIndex = 3;
            this.programStatusStrip.Text = "statusStrip1";
            // 
            // wordsFontDialog
            // 
            this.wordsFontDialog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // backgroundColorDialog
            // 
            this.backgroundColorDialog.Color = System.Drawing.Color.White;
            // 
            // backgroundCloudCreator
            // 
            this.backgroundCloudCreator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundCloudCreator_DoWork);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "Png|*.png|Jpeg|*.jpeg";
            this.saveImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveImageDialog_FileOk);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.progressLabel.Location = new System.Drawing.Point(620, 544);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(23, 15);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "0%";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cancelCreatingButton
            // 
            this.cancelCreatingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelCreatingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cancelCreatingButton.Enabled = false;
            this.cancelCreatingButton.Location = new System.Drawing.Point(752, 538);
            this.cancelCreatingButton.Name = "cancelCreatingButton";
            this.cancelCreatingButton.Size = new System.Drawing.Size(87, 27);
            this.cancelCreatingButton.TabIndex = 9;
            this.cancelCreatingButton.Text = "Stop";
            this.cancelCreatingButton.UseVisualStyleBackColor = false;
            this.cancelCreatingButton.Click += new System.EventHandler(this.cancelCreatingButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(854, 611);
            this.Controls.Add(this.cancelCreatingButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.cloudCreatingProgress);
            this.Controls.Add(this.generateCloudButton);
            this.Controls.Add(this.cloudImageBox);
            this.Controls.Add(this.programStatusStrip);
            this.Controls.Add(this.imageSizeGroup);
            this.Controls.Add(this.cloudGeneratingGroup);
            this.Controls.Add(this.textLoadGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(744, 548);
            this.Name = "MainForm";
            this.Text = "Tag cloud generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewForm_DragEnter);
            this.textLoadGroup.ResumeLayout(false);
            this.textLoadGroup.PerformLayout();
            this.cloudGeneratingGroup.ResumeLayout(false);
            this.cloudGeneratingGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstWordScaleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsAmountBar)).EndInit();
            this.imageSizeGroup.ResumeLayout(false);
            this.imageSizeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudImageBox)).EndInit();
            this.programStatusStrip.ResumeLayout(false);
            this.programStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox textLoadGroup;
        private System.Windows.Forms.GroupBox cloudGeneratingGroup;
        private System.Windows.Forms.GroupBox imageSizeGroup;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button browseFileButton;
        private System.Windows.Forms.NumericUpDown imageHeight;
        private System.Windows.Forms.NumericUpDown imageWidth;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.OpenFileDialog loadTextDialog;
        private System.Windows.Forms.Label templateLabel;
        private System.Windows.Forms.ComboBox templateSelector;
        private System.Windows.Forms.PictureBox cloudImageBox;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.Button generateCloudButton;
        private System.Windows.Forms.Label firstWordScaleLabel;
        private System.Windows.Forms.Label wordsAmountLabel;
        private System.Windows.Forms.TrackBar firstWordScaleBar;
        private System.Windows.Forms.TrackBar wordsAmountBar;
        private System.Windows.Forms.PictureBox backgroundColor;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.Label fontStringLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Button wordsColorsButton;
        private System.Windows.Forms.Label wordsColorsLabel;
        private System.Windows.Forms.ToolStripStatusLabel programStatus;
        private System.Windows.Forms.StatusStrip programStatusStrip;
        private System.Windows.Forms.ColorDialog wordsColorDialog;
        private System.Windows.Forms.FontDialog wordsFontDialog;
        private System.Windows.Forms.ColorDialog backgroundColorDialog;
        private System.ComponentModel.BackgroundWorker backgroundCloudCreator;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.TextBox loadedFilePath;
        private System.Windows.Forms.Label colorsCountLabel;
        public System.Windows.Forms.ProgressBar cloudCreatingProgress;
        public System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.CheckBox recreateCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button cancelCreatingButton;
        private System.Windows.Forms.CheckBox shouldStemWordsCheckBox;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.NumericUpDown accuracyNumericUpDown;
    }
}