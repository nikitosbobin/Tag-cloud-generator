using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Tag_Cloud_Generator.Classes;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Properties;

namespace Tag_Cloud_Generator
{
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
            LoadTemplates();
            data = new FormDataProvider();
            decoder = new TxtDecoder();
        }

        
        private FormDataProvider data;
        private readonly ITextDecoder decoder;

        private readonly Dictionary<string, Size> templates = new Dictionary<string, Size>
        {
            {"SD (720x576)", new Size(720, 576)},
            {"HD (1280x720)", new Size(1280, 720)},
            {"Full HD (1920x1080)", new Size(1920, 1080)},
            {"2K (2048x1080)", new Size(2048, 1080)},
            {"4K (3840x2160)", new Size(3840, 2160)}
        };

        private void LoadTemplates()
        {
            foreach (var template in templates)
                templateSelector.Items.Add(template.Key);
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            loadTextDialog.ShowDialog(this);
        }

        private void fontButton_Click(object sender, EventArgs e)
        {

        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {

        }

        private void wordsColorsButton_Click(object sender, EventArgs e)
        {

        }

        private void generateCloudButton_Click(object sender, EventArgs e)
        {

        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {

        }

        private void loadTextDialog_FileOk(object sender, CancelEventArgs e)
        {
            LoadText(loadTextDialog.FileName);
        }

        private void NewForm_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false)).First();
            try { LoadText(path); }
            catch { MessageBox.Show(Resources.NewForm_NewForm_DragDrop_Can_not_read_file); }
        }

        private void LoadText(string path)
        {
            decoder.TextLines = File.ReadAllLines(path);
            loadedFilePath.Text = path;
            imageSizeGroup.Enabled = true;
            cloudGeneratingGroup.Enabled = true;
            generateCloudButton.Enabled = true;
            programStatus.Text = Resources.NewForm_LoadText_Ready_to_create;
        }

        private void NewForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void templateSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var size = templates[(string) templateSelector.SelectedItem];
            imageWidth.Value = size.Width;
            imageHeight.Value = size.Height;
        }
    }
}
