namespace Tag_Cloud_Generator
{
    partial class NewForm
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
            this.textLoadGroup = new System.Windows.Forms.GroupBox();
            this.loadedFilePath = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.browseFileButton = new System.Windows.Forms.Button();
            this.cloudGeneratingGroup = new System.Windows.Forms.GroupBox();
            this.wordsColorsButton = new System.Windows.Forms.Button();
            this.wordsColorsLabel = new System.Windows.Forms.Label();
            this.backgroundColor = new System.Windows.Forms.PictureBox();
            this.backgroundColorButton = new System.Windows.Forms.Button();
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
            this.saveImageButton = new System.Windows.Forms.Button();
            this.generateCloudButton = new System.Windows.Forms.Button();
            this.cloudCreatingProgress = new System.Windows.Forms.ProgressBar();
            this.programStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.programStatusStrip = new System.Windows.Forms.StatusStrip();
            this.wordsColorDialog = new System.Windows.Forms.ColorDialog();
            this.wordsFontDialog = new System.Windows.Forms.FontDialog();
            this.backgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundCloudCreator = new System.ComponentModel.BackgroundWorker();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.textLoadGroup.SuspendLayout();
            this.cloudGeneratingGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstWordScaleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsAmountBar)).BeginInit();
            this.imageSizeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudImageBox)).BeginInit();
            this.programStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLoadGroup
            // 
            this.textLoadGroup.Controls.Add(this.loadedFilePath);
            this.textLoadGroup.Controls.Add(this.fileLabel);
            this.textLoadGroup.Controls.Add(this.browseFileButton);
            this.textLoadGroup.Location = new System.Drawing.Point(12, 12);
            this.textLoadGroup.Name = "textLoadGroup";
            this.textLoadGroup.Size = new System.Drawing.Size(299, 62);
            this.textLoadGroup.TabIndex = 0;
            this.textLoadGroup.TabStop = false;
            this.textLoadGroup.Text = "Text load";
            // 
            // loadedFilePath
            // 
            this.loadedFilePath.Location = new System.Drawing.Point(42, 25);
            this.loadedFilePath.Name = "loadedFilePath";
            this.loadedFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loadedFilePath.Size = new System.Drawing.Size(170, 20);
            this.loadedFilePath.TabIndex = 2;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(6, 27);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(30, 15);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "File:";
            // 
            // browseFileButton
            // 
            this.browseFileButton.Location = new System.Drawing.Point(218, 24);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(75, 23);
            this.browseFileButton.TabIndex = 0;
            this.browseFileButton.Text = "Browse...";
            this.browseFileButton.UseVisualStyleBackColor = true;
            this.browseFileButton.Click += new System.EventHandler(this.browseFileButton_Click);
            // 
            // cloudGeneratingGroup
            // 
            this.cloudGeneratingGroup.Controls.Add(this.wordsColorsButton);
            this.cloudGeneratingGroup.Controls.Add(this.wordsColorsLabel);
            this.cloudGeneratingGroup.Controls.Add(this.backgroundColor);
            this.cloudGeneratingGroup.Controls.Add(this.backgroundColorButton);
            this.cloudGeneratingGroup.Controls.Add(this.backgroundLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontStringLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontLabel);
            this.cloudGeneratingGroup.Controls.Add(this.fontButton);
            this.cloudGeneratingGroup.Controls.Add(this.firstWordScaleLabel);
            this.cloudGeneratingGroup.Controls.Add(this.wordsAmountLabel);
            this.cloudGeneratingGroup.Controls.Add(this.firstWordScaleBar);
            this.cloudGeneratingGroup.Controls.Add(this.wordsAmountBar);
            this.cloudGeneratingGroup.Enabled = false;
            this.cloudGeneratingGroup.Location = new System.Drawing.Point(327, 117);
            this.cloudGeneratingGroup.Name = "cloudGeneratingGroup";
            this.cloudGeneratingGroup.Size = new System.Drawing.Size(285, 246);
            this.cloudGeneratingGroup.TabIndex = 1;
            this.cloudGeneratingGroup.TabStop = false;
            this.cloudGeneratingGroup.Text = "Cloud generating";
            // 
            // wordsColorsButton
            // 
            this.wordsColorsButton.Location = new System.Drawing.Point(191, 176);
            this.wordsColorsButton.Name = "wordsColorsButton";
            this.wordsColorsButton.Size = new System.Drawing.Size(75, 23);
            this.wordsColorsButton.TabIndex = 11;
            this.wordsColorsButton.Text = "Change";
            this.wordsColorsButton.UseVisualStyleBackColor = true;
            this.wordsColorsButton.Click += new System.EventHandler(this.wordsColorsButton_Click);
            // 
            // wordsColorsLabel
            // 
            this.wordsColorsLabel.AutoSize = true;
            this.wordsColorsLabel.Location = new System.Drawing.Point(3, 181);
            this.wordsColorsLabel.Name = "wordsColorsLabel";
            this.wordsColorsLabel.Size = new System.Drawing.Size(72, 13);
            this.wordsColorsLabel.TabIndex = 10;
            this.wordsColorsLabel.Text = "Words colors:";
            // 
            // backgroundColor
            // 
            this.backgroundColor.Location = new System.Drawing.Point(77, 141);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(71, 22);
            this.backgroundColor.TabIndex = 9;
            this.backgroundColor.TabStop = false;
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(191, 140);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(75, 23);
            this.backgroundColorButton.TabIndex = 8;
            this.backgroundColorButton.Text = "Change";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Location = new System.Drawing.Point(3, 145);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(68, 13);
            this.backgroundLabel.TabIndex = 7;
            this.backgroundLabel.Text = "Background:";
            // 
            // fontStringLabel
            // 
            this.fontStringLabel.AutoSize = true;
            this.fontStringLabel.Location = new System.Drawing.Point(48, 110);
            this.fontStringLabel.Name = "fontStringLabel";
            this.fontStringLabel.Size = new System.Drawing.Size(97, 13);
            this.fontStringLabel.TabIndex = 6;
            this.fontStringLabel.Text = "Times New Roman";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(3, 110);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(34, 13);
            this.fontLabel.TabIndex = 5;
            this.fontLabel.Text = "Font: ";
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(191, 105);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(75, 23);
            this.fontButton.TabIndex = 4;
            this.fontButton.Text = "Change";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // firstWordScaleLabel
            // 
            this.firstWordScaleLabel.AutoSize = true;
            this.firstWordScaleLabel.Location = new System.Drawing.Point(169, 27);
            this.firstWordScaleLabel.MaximumSize = new System.Drawing.Size(135, 50);
            this.firstWordScaleLabel.Name = "firstWordScaleLabel";
            this.firstWordScaleLabel.Size = new System.Drawing.Size(80, 13);
            this.firstWordScaleLabel.TabIndex = 3;
            this.firstWordScaleLabel.Text = "First word scale";
            // 
            // wordsAmountLabel
            // 
            this.wordsAmountLabel.AutoSize = true;
            this.wordsAmountLabel.Location = new System.Drawing.Point(34, 29);
            this.wordsAmountLabel.Name = "wordsAmountLabel";
            this.wordsAmountLabel.Size = new System.Drawing.Size(76, 13);
            this.wordsAmountLabel.TabIndex = 2;
            this.wordsAmountLabel.Text = "Words amount";
            // 
            // firstWordScaleBar
            // 
            this.firstWordScaleBar.Location = new System.Drawing.Point(144, 56);
            this.firstWordScaleBar.Name = "firstWordScaleBar";
            this.firstWordScaleBar.Size = new System.Drawing.Size(129, 45);
            this.firstWordScaleBar.TabIndex = 1;
            // 
            // wordsAmountBar
            // 
            this.wordsAmountBar.Location = new System.Drawing.Point(6, 56);
            this.wordsAmountBar.Name = "wordsAmountBar";
            this.wordsAmountBar.Size = new System.Drawing.Size(132, 45);
            this.wordsAmountBar.TabIndex = 0;
            // 
            // imageSizeGroup
            // 
            this.imageSizeGroup.Controls.Add(this.templateLabel);
            this.imageSizeGroup.Controls.Add(this.templateSelector);
            this.imageSizeGroup.Controls.Add(this.imageHeight);
            this.imageSizeGroup.Controls.Add(this.imageWidth);
            this.imageSizeGroup.Controls.Add(this.heightLabel);
            this.imageSizeGroup.Controls.Add(this.widthLabel);
            this.imageSizeGroup.Enabled = false;
            this.imageSizeGroup.Location = new System.Drawing.Point(327, 12);
            this.imageSizeGroup.Name = "imageSizeGroup";
            this.imageSizeGroup.Size = new System.Drawing.Size(285, 99);
            this.imageSizeGroup.TabIndex = 2;
            this.imageSizeGroup.TabStop = false;
            this.imageSizeGroup.Text = "Tag cloud size";
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Location = new System.Drawing.Point(3, 29);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(57, 13);
            this.templateLabel.TabIndex = 5;
            this.templateLabel.Text = "Template: ";
            // 
            // templateSelector
            // 
            this.templateSelector.FormattingEnabled = true;
            this.templateSelector.Location = new System.Drawing.Point(64, 24);
            this.templateSelector.Name = "templateSelector";
            this.templateSelector.Size = new System.Drawing.Size(215, 21);
            this.templateSelector.TabIndex = 4;
            this.templateSelector.SelectedIndexChanged += new System.EventHandler(this.templateSelector_SelectedIndexChanged);
            // 
            // imageHeight
            // 
            this.imageHeight.Location = new System.Drawing.Point(206, 59);
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
            this.imageHeight.Size = new System.Drawing.Size(65, 20);
            this.imageHeight.TabIndex = 3;
            this.imageHeight.Value = new decimal(new int[] {
            576,
            0,
            0,
            0});
            // 
            // imageWidth
            // 
            this.imageWidth.Location = new System.Drawing.Point(64, 59);
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
            this.imageWidth.Size = new System.Drawing.Size(65, 20);
            this.imageWidth.TabIndex = 2;
            this.imageWidth.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(160, 61);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(44, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height: ";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(17, 61);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(41, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width: ";
            // 
            // loadTextDialog
            // 
            this.loadTextDialog.FileName = "loadTextDialog";
            this.loadTextDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadTextDialog_FileOk);
            // 
            // cloudImageBox
            // 
            this.cloudImageBox.Location = new System.Drawing.Point(12, 80);
            this.cloudImageBox.Name = "cloudImageBox";
            this.cloudImageBox.Size = new System.Drawing.Size(299, 283);
            this.cloudImageBox.TabIndex = 4;
            this.cloudImageBox.TabStop = false;
            // 
            // saveImageButton
            // 
            this.saveImageButton.Enabled = false;
            this.saveImageButton.Location = new System.Drawing.Point(537, 378);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(75, 23);
            this.saveImageButton.TabIndex = 5;
            this.saveImageButton.Text = "Save as";
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // generateCloudButton
            // 
            this.generateCloudButton.Enabled = false;
            this.generateCloudButton.Location = new System.Drawing.Point(456, 378);
            this.generateCloudButton.Name = "generateCloudButton";
            this.generateCloudButton.Size = new System.Drawing.Size(75, 23);
            this.generateCloudButton.TabIndex = 6;
            this.generateCloudButton.Text = "Generate";
            this.generateCloudButton.UseVisualStyleBackColor = true;
            this.generateCloudButton.Click += new System.EventHandler(this.generateCloudButton_Click);
            // 
            // cloudCreatingProgress
            // 
            this.cloudCreatingProgress.Location = new System.Drawing.Point(12, 378);
            this.cloudCreatingProgress.Name = "cloudCreatingProgress";
            this.cloudCreatingProgress.Size = new System.Drawing.Size(438, 23);
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
            this.programStatusStrip.Location = new System.Drawing.Point(0, 419);
            this.programStatusStrip.Name = "programStatusStrip";
            this.programStatusStrip.Size = new System.Drawing.Size(624, 22);
            this.programStatusStrip.SizingGrip = false;
            this.programStatusStrip.TabIndex = 3;
            this.programStatusStrip.Text = "statusStrip1";
            // 
            // backgroundColorDialog
            // 
            this.backgroundColorDialog.Color = System.Drawing.Color.White;
            // 
            // NewForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.cloudCreatingProgress);
            this.Controls.Add(this.generateCloudButton);
            this.Controls.Add(this.saveImageButton);
            this.Controls.Add(this.cloudImageBox);
            this.Controls.Add(this.programStatusStrip);
            this.Controls.Add(this.imageSizeGroup);
            this.Controls.Add(this.cloudGeneratingGroup);
            this.Controls.Add(this.textLoadGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewForm";
            this.Text = "Tag cloud generator";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewForm_DragEnter);
            this.textLoadGroup.ResumeLayout(false);
            this.textLoadGroup.PerformLayout();
            this.cloudGeneratingGroup.ResumeLayout(false);
            this.cloudGeneratingGroup.PerformLayout();
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
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.Label fontStringLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Button wordsColorsButton;
        private System.Windows.Forms.Label wordsColorsLabel;
        private System.Windows.Forms.ProgressBar cloudCreatingProgress;
        private System.Windows.Forms.ToolStripStatusLabel programStatus;
        private System.Windows.Forms.StatusStrip programStatusStrip;
        private System.Windows.Forms.ColorDialog wordsColorDialog;
        private System.Windows.Forms.FontDialog wordsFontDialog;
        private System.Windows.Forms.ColorDialog backgroundColorDialog;
        private System.ComponentModel.BackgroundWorker backgroundCloudCreator;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.TextBox loadedFilePath;
    }
}