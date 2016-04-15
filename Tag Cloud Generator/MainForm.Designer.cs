namespace Tag_Cloud_Generator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backgroundColor = new System.Windows.Forms.PictureBox();
            this.setBcgColorButton = new System.Windows.Forms.Button();
            this.deleteColorButton = new System.Windows.Forms.Button();
            this.colorsListView = new System.Windows.Forms.ListView();
            this.Colors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addColorButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.wordsCountBar = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cloudCreateProgress = new System.Windows.Forms.ProgressBar();
            this.createCloudButton = new System.Windows.Forms.Button();
            this.fontLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageWidth = new System.Windows.Forms.NumericUpDown();
            this.imageHeight = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.asyncCloudCreator = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColor)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsCountBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            this.openFileDialog1.Tag = "";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(8, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 354);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inputTextBox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File load";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inputTextBox
            // 
            this.inputTextBox.AllowDrop = true;
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(6, 6);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(514, 287);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.inputTextBox_DragDrop);
            this.inputTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.inputTextBox_DragEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.backgroundColor);
            this.tabPage2.Controls.Add(this.setBcgColorButton);
            this.tabPage2.Controls.Add(this.deleteColorButton);
            this.tabPage2.Controls.Add(this.colorsListView);
            this.tabPage2.Controls.Add(this.addColorButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Colors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // backgroundColor
            // 
            this.backgroundColor.Location = new System.Drawing.Point(297, 64);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(17, 17);
            this.backgroundColor.TabIndex = 7;
            this.backgroundColor.TabStop = false;
            // 
            // setBcgColorButton
            // 
            this.setBcgColorButton.Location = new System.Drawing.Point(216, 64);
            this.setBcgColorButton.Name = "setBcgColorButton";
            this.setBcgColorButton.Size = new System.Drawing.Size(75, 23);
            this.setBcgColorButton.TabIndex = 6;
            this.setBcgColorButton.Text = "Background";
            this.setBcgColorButton.UseVisualStyleBackColor = true;
            this.setBcgColorButton.Click += new System.EventHandler(this.setBcgColorButton_Click);
            // 
            // deleteColorButton
            // 
            this.deleteColorButton.Location = new System.Drawing.Point(216, 35);
            this.deleteColorButton.Name = "deleteColorButton";
            this.deleteColorButton.Size = new System.Drawing.Size(75, 23);
            this.deleteColorButton.TabIndex = 5;
            this.deleteColorButton.Text = "Delete";
            this.deleteColorButton.UseVisualStyleBackColor = true;
            this.deleteColorButton.Click += new System.EventHandler(this.deleteColorButton_Click);
            // 
            // colorsListView
            // 
            this.colorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.colorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Colors});
            this.colorsListView.FullRowSelect = true;
            this.colorsListView.GridLines = true;
            this.colorsListView.Location = new System.Drawing.Point(6, 6);
            this.colorsListView.Name = "colorsListView";
            this.colorsListView.Size = new System.Drawing.Size(190, 373);
            this.colorsListView.TabIndex = 4;
            this.colorsListView.UseCompatibleStateImageBehavior = false;
            this.colorsListView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(216, 6);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(75, 23);
            this.addColorButton.TabIndex = 0;
            this.addColorButton.Text = "Add color";
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.wordsCountBar);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.cloudCreateProgress);
            this.tabPage3.Controls.Add(this.createCloudButton);
            this.tabPage3.Controls.Add(this.fontLabel);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.imageWidth);
            this.tabPage3.Controls.Add(this.imageHeight);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(526, 328);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cloud settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // wordsCountBar
            // 
            this.wordsCountBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wordsCountBar.Location = new System.Drawing.Point(11, 134);
            this.wordsCountBar.Maximum = 100;
            this.wordsCountBar.Name = "wordsCountBar";
            this.wordsCountBar.Size = new System.Drawing.Size(174, 45);
            this.wordsCountBar.SmallChange = 10;
            this.wordsCountBar.TabIndex = 11;
            this.wordsCountBar.TickFrequency = 10;
            this.wordsCountBar.Value = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(248, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // cloudCreateProgress
            // 
            this.cloudCreateProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cloudCreateProgress.Location = new System.Drawing.Point(8, 297);
            this.cloudCreateProgress.Name = "cloudCreateProgress";
            this.cloudCreateProgress.Size = new System.Drawing.Size(510, 23);
            this.cloudCreateProgress.TabIndex = 9;
            // 
            // createCloudButton
            // 
            this.createCloudButton.Location = new System.Drawing.Point(167, 325);
            this.createCloudButton.Name = "createCloudButton";
            this.createCloudButton.Size = new System.Drawing.Size(75, 23);
            this.createCloudButton.TabIndex = 8;
            this.createCloudButton.Text = "Create cloud";
            this.createCloudButton.UseVisualStyleBackColor = true;
            this.createCloudButton.Click += new System.EventHandler(this.createCloudButton_Click);
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(106, 93);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(97, 13);
            this.fontLabel.TabIndex = 7;
            this.fontLabel.Text = "Times New Roman";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Choose font";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width:";
            // 
            // imageWidth
            // 
            this.imageWidth.Location = new System.Drawing.Point(68, 14);
            this.imageWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.imageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageWidth.Name = "imageWidth";
            this.imageWidth.Size = new System.Drawing.Size(46, 20);
            this.imageWidth.TabIndex = 3;
            this.imageWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // imageHeight
            // 
            this.imageHeight.Location = new System.Drawing.Point(68, 52);
            this.imageHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.imageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageHeight.Name = "imageHeight";
            this.imageHeight.Size = new System.Drawing.Size(46, 20);
            this.imageHeight.TabIndex = 2;
            this.imageHeight.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // asyncCloudCreator
            // 
            this.asyncCloudCreator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.asyncCloudCreator_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(550, 450);
            this.Name = "MainForm";
            this.Text = "Tag cloud generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsCountBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.ListView colorsListView;
        private System.Windows.Forms.ColumnHeader Colors;
        private System.Windows.Forms.Button deleteColorButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown imageHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown imageWidth;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button createCloudButton;
        private System.ComponentModel.BackgroundWorker asyncCloudCreator;
        public System.Windows.Forms.ProgressBar cloudCreateProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button setBcgColorButton;
        private System.Windows.Forms.PictureBox backgroundColor;
        private System.Windows.Forms.ColorDialog backgroundColorDialog;
        private System.Windows.Forms.TrackBar wordsCountBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

