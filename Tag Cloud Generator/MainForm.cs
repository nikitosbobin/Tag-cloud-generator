using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Tag_Cloud_Generator.Classes;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;
using Tag_Cloud_Generator.Properties;

namespace Tag_Cloud_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadTemplates();
            backgroundColor.Image = GetImage(Color.White);
            data = new FormDataProvider
            {
                WordsColors = null,
                BackGroundColor = Color.White,
                WordsFont = new Font("Segoe UI", 12f),
                WordsCount = 30
            };
            decoder = new TxtDecoder();
            colorsForm = new WordsColorsForm();
            textHandler = new SimpleTextHandler();
            imageGenerator = new ImageGenerator();
            cloudIsRelevant = false;
            cloudGenerator = new RelativeChoiceCloud(decoder, textHandler, this);
        }

        private bool cloudIsRelevant;
        private readonly FormDataProvider data;
        private readonly ITextDecoder decoder;
        private readonly ITextHandler textHandler;
        private readonly ICloudImageGenerator imageGenerator;
        private ICloudGenerator cloudGenerator;
        private readonly WordsColorsForm colorsForm;
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
            if (wordsFontDialog.ShowDialog(this) != DialogResult.OK) return;
            data.WordsFont = wordsFontDialog.Font;
            fontStringLabel.Text = data.WordsFont.Name;
            cloudIsRelevant = false;
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog(this) != DialogResult.OK) return;
            data.BackGroundColor = backgroundColorDialog.Color;
            backgroundColor.Image = GetImage(data.BackGroundColor);
        }

        public void SetProgress(int value)
        {
            cloudCreatingProgress.Value = value;
            progressLabel.Text = $"{value}%";
        }

        private Bitmap GetImage(Color color)
        {
            var image = new Bitmap(80, 30);
            var graphics = Graphics.FromImage(image);
            graphics.Clear(color);
            graphics.Dispose();
            return image;
        }

        private void wordsColorsButton_Click(object sender, EventArgs e)
        {
            if (colorsForm.ShowDialog(this) != DialogResult.OK) return;
            data.WordsColors = colorsForm.Colors;
            colorsCountLabel.Text = data.WordsColors.Count.ToString();
        }

        private void generateCloudButton_Click(object sender, EventArgs e)
        {
            saveImageButton.Enabled = false;
            if (recreateCheckBox.Checked)
                cloudIsRelevant = false;
            backgroundCloudCreator.RunWorkerAsync();
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            saveImageDialog.FileName = $"cloud[{date.Day}_{date.Month}_{date.Year}][{date.Hour}_{date.Minute}_{date.Second}]";
            saveImageDialog.ShowDialog(this);
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
            cloudIsRelevant = false;
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

        private void cloudCreatingProgress_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundCloudCreator_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                generateCloudButton.Enabled = false;
                cloudGeneratingGroup.Enabled = false;
                imageSizeGroup.Enabled = false;
                textLoadGroup.Enabled = false;
                programStatus.Text = "Creating";
            });
            Bitmap image;
            try
            {
                if (cloudIsRelevant)
                    image = imageGenerator.CreateImage(cloudGenerator, data.BackGroundColor, data.WordsColors);
                else
                {
                    imageGenerator.ImageSize = new Size((int)imageWidth.Value, (int)imageHeight.Value);
                    image = imageGenerator.CreateImage(cloudGenerator, data.WordsFont, data.WordsCount, data.BackGroundColor, data.WordsColors);
                    cloudIsRelevant = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.Contains("no words")
                    ? "There are no words to build cloud"
                    : exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                programStatus.Text = "Error";
                generateCloudButton.Enabled = true;
                cloudGeneratingGroup.Enabled = true;
                imageSizeGroup.Enabled = true;
                textLoadGroup.Enabled = true;
                SetProgress(0);
                return;
            }
            Invoke((MethodInvoker)delegate
            {
                generateCloudButton.Enabled = true;
                cloudGeneratingGroup.Enabled = true;
                imageSizeGroup.Enabled = true;
                textLoadGroup.Enabled = true;
                cloudImageBox.Image = image;
                programStatus.Text = "Done";
                SetProgress(0);
                saveImageButton.Enabled = true;
            });
        }

        private void imageWidth_ValueChanged(object sender, EventArgs e)
        {
            cloudIsRelevant = false;
        }

        private void imageHeight_ValueChanged(object sender, EventArgs e)
        {
            cloudIsRelevant = false;
        }

        private void wordsAmountBar_Scroll(object sender, EventArgs e)
        {
            data.WordsCount = wordsAmountBar.Value;
            cloudIsRelevant = false;
        }

        private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            programStatus.Text = "Saving";
            cloudImageBox.Image.Save(saveImageDialog.FileName);
            programStatus.Text = "Done";
        }
    }
}
