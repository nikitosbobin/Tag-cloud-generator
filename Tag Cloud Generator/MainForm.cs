﻿using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
                WordsCount = 30,
                FirstScale = 10
            };
            colorsForm = new WordsColorsForm();
            imageGenerator = new ImageGenerator();
            cloudIsRelevant = false;
            textHandler = new TextSpellHandler();
            cloudGenerator = new RelativeChoiceCloud(textHandler);
        }

        private bool cloudIsRelevant;
        private ITagCloud actualCloud;
        private readonly FormDataProvider data;
        private readonly ImageGenerator imageGenerator;
        private readonly ICloudGenerator cloudGenerator;
        private readonly TextSpellHandler textHandler;
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
            data.ImageSize = new Size((int) imageWidth.Value, (int)imageHeight.Value);
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
            textHandler.TextLines = File.ReadAllLines(path, Encoding.Default);
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

        private void backgroundCloudCreator_DoWork(object sender, DoWorkEventArgs e)
        {
            SetFormToStartSreating();
            Bitmap image;
            try
            {
                image = TryCreateCloud();
            }
            catch (Exception exception)
            {
                SetFormCreatingFailed(exception);
                return;
            }
            SetFormCreatingSuccess(image);
        }

        private Bitmap TryCreateCloud()
        {
            Bitmap image;
            if (cloudIsRelevant)
                image = imageGenerator.CreateImage(actualCloud, data.BackGroundColor, data.WordsColors);
            else
            {
                actualCloud = CreateImage(cloudGenerator, data, v =>
                {
                    Invoke((MethodInvoker)delegate { SetProgress(v); });
                });
                cloudIsRelevant = true;
                image = imageGenerator.CreateImage(actualCloud, data.BackGroundColor, data.WordsColors);
            }
            return image;
        }

        private void SetFormCreatingFailed(Exception exception)
        {
            Invoke((MethodInvoker) delegate
            {
                MessageBox.Show(exception.Message.Contains("no words")
                    ? "There are no words to build cloud"
                    : exception.Message, Resources.MainForm_backgroundCloudCreator_DoWork_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                programStatus.Text = Resources.MainForm_backgroundCloudCreator_DoWork_Error;
                SwitchInputControls(true);
                SetProgress(0);
            });
        }

        private void SetFormToStartSreating()
        {
            Invoke((MethodInvoker)delegate
            {
                SwitchInputControls(false);
                programStatus.Text = Resources.MainForm_backgroundCloudCreator_DoWork_Creating;
            });
        }

        private void SetFormCreatingSuccess(Image createdImage)
        {
            Invoke((MethodInvoker)delegate
            {
                SwitchInputControls(true);
                SetProgress(0);
                cloudImageBox.Image = createdImage;
                programStatus.Text = Resources.MainForm_backgroundCloudCreator_DoWork_Done;
            });
        }

        private void SwitchInputControls(bool value)
        {
            Invoke((MethodInvoker) delegate
            {
                generateCloudButton.Enabled = value;
                cloudGeneratingGroup.Enabled = value;
                imageSizeGroup.Enabled = value;
                textLoadGroup.Enabled = value;
                saveImageButton.Enabled = value;
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
            programStatus.Text = Resources.MainForm_saveImageDialog_FileOk_Saving;
            cloudImageBox.Image.Save(saveImageDialog.FileName);
            programStatus.Text = Resources.MainForm_backgroundCloudCreator_DoWork_Done;
        }

        private void firstWordScaleBar_Scroll(object sender, EventArgs e)
        {
            cloudIsRelevant = false;
            data.FirstScale = firstWordScaleBar.Value;
        }

        private void backgroundColor_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog(this) != DialogResult.OK) return;
            data.BackGroundColor = backgroundColorDialog.Color;
            backgroundColor.Image = GetImage(data.BackGroundColor);
        }
        
        private ITagCloud CreateImage(ICloudGenerator cloud, FormDataProvider data, Action<int> setProgress = null)
        {
            return cloud.CreateCloud(data.ImageSize, data.WordsFont, data.WordsCount, data.FirstScale, setProgress);
        }
    }
}
