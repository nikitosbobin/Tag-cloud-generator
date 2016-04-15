namespace Tag_Cloud_Generator
{
    partial class WordsColorsForm
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
            this.colorsListView = new System.Windows.Forms.ListView();
            this.acceptButton = new System.Windows.Forms.Button();
            this.addColorButton = new System.Windows.Forms.Button();
            this.deleteColorButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // colorsListView
            // 
            this.colorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.colorsListView.FullRowSelect = true;
            this.colorsListView.GridLines = true;
            this.colorsListView.Location = new System.Drawing.Point(12, 12);
            this.colorsListView.Name = "colorsListView";
            this.colorsListView.Size = new System.Drawing.Size(184, 178);
            this.colorsListView.TabIndex = 0;
            this.colorsListView.UseCompatibleStateImageBehavior = false;
            this.colorsListView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(308, 167);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(218, 12);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(75, 23);
            this.addColorButton.TabIndex = 2;
            this.addColorButton.Text = "Add";
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // deleteColorButton
            // 
            this.deleteColorButton.Location = new System.Drawing.Point(218, 41);
            this.deleteColorButton.Name = "deleteColorButton";
            this.deleteColorButton.Size = new System.Drawing.Size(75, 23);
            this.deleteColorButton.TabIndex = 3;
            this.deleteColorButton.Text = "Delete";
            this.deleteColorButton.UseVisualStyleBackColor = true;
            this.deleteColorButton.Click += new System.EventHandler(this.deleteColorButton_Click);
            // 
            // WordsColorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 202);
            this.Controls.Add(this.deleteColorButton);
            this.Controls.Add(this.addColorButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.colorsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WordsColorsForm";
            this.Text = "Choose colors";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.Button deleteColorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView colorsListView;
    }
}