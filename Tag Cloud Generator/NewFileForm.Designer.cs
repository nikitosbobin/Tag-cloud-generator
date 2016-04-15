namespace Tag_Cloud_Generator
{
    partial class NewFileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthNumericInput = new System.Windows.Forms.NumericUpDown();
            this.heightNumericInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.patternSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            // 
            // widthNumericInput
            // 
            this.widthNumericInput.Location = new System.Drawing.Point(53, 81);
            this.widthNumericInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthNumericInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericInput.Name = "widthNumericInput";
            this.widthNumericInput.Size = new System.Drawing.Size(70, 20);
            this.widthNumericInput.TabIndex = 2;
            this.widthNumericInput.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // heightNumericInput
            // 
            this.heightNumericInput.Location = new System.Drawing.Point(53, 118);
            this.heightNumericInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightNumericInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericInput.Name = "heightNumericInput";
            this.heightNumericInput.Size = new System.Drawing.Size(70, 20);
            this.heightNumericInput.TabIndex = 3;
            this.heightNumericInput.Value = new decimal(new int[] {
            576,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Input image size";
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(116, 156);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 5;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(197, 156);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // patternSelector
            // 
            this.patternSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patternSelector.AutoCompleteCustomSource.AddRange(new string[] {
            "SD (720x576)",
            "HD (1280x720)",
            "Full HD (1920x1080)",
            "2K (2048x1080)",
            "4K (3840x2160)"});
            this.patternSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patternSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patternSelector.FormattingEnabled = true;
            this.patternSelector.Items.AddRange(new object[] {
            "SD (720x576)",
            "HD (1280x720)",
            "Full HD (1920x1080)",
            "2K (2048x1080)",
            "4K (3840x2160)"});
            this.patternSelector.Location = new System.Drawing.Point(67, 12);
            this.patternSelector.Name = "patternSelector";
            this.patternSelector.Size = new System.Drawing.Size(205, 21);
            this.patternSelector.TabIndex = 7;
            this.patternSelector.SelectedIndexChanged += new System.EventHandler(this.patternSelector_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tempate:";
            // 
            // NewFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.patternSelector);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heightNumericInput);
            this.Controls.Add(this.widthNumericInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewFileForm";
            this.Text = "Create new file";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewFileForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown widthNumericInput;
        private System.Windows.Forms.NumericUpDown heightNumericInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox patternSelector;
        private System.Windows.Forms.Label label4;
    }
}