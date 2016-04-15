using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tag_Cloud_Generator.Classes;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator
{
    public partial class MainForm : Form
    {
        private readonly ITextDecoder decoder;
        private readonly ITextHandler textHandler;
        private ICloudImageGenerator imageGenerator;
        private ICloudGenerator cloudGenerator;
        private readonly WordsColorsForm colorsForm;
        private readonly FormDataProvider dataProvider;
        public MainForm()
        {
            InitializeComponent();
            textHandler = new SimpleTextHandler();
            decoder = new TxtDecoder();
            colorsForm = new WordsColorsForm();
            dataProvider = new FormDataProvider
            {
                WordsColors = null,
                BackGroundColor = Color.Black,
                WordsFont = new Font("Times New Roman", 12f),
                WordsCount = 30
            };
            SwitchElementsEnabled(false);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var openFileDialog = sender as OpenFileDialog;
                if (openFileDialog == null)
                {
                    MessageBox.Show("Something wrong");
                    return;
                }
                var path = openFileDialog.FileName;
                inputTextBox.Lines = File.ReadAllLines(path);
            }
            catch
            {
                MessageBox.Show("Can not read file");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void createCloudButton_Click(object sender, EventArgs e)
        {
            decoder.TextLines = inputTextBox.Lines;
            imageGenerator = new ImageGenerator(dataProvider.ImageSize);
            cloudGenerator = new RelativeChoiceCloud(decoder, textHandler, imageGenerator, this);
            asyncCloudCreator.RunWorkerAsync();
        }

        private void SwitchElementsEnabled(bool enabled)
        {
            saveAsToolStripMenuItem.Enabled = enabled;
            tabControl1.Enabled = enabled;
            editToolStripMenuItem.Enabled = enabled;
        }

        private void asyncCloudCreator_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker) delegate
            {
                createCloudButton.Enabled = false;
                programStatus.Text = "Creating";
            });
            Bitmap image;
            try
            {
                image = imageGenerator.CreateImage(cloudGenerator, dataProvider.WordsFont,
                    dataProvider.WordsCount, dataProvider.BackGroundColor, dataProvider.WordsColors);
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("no words")) return;
                MessageBox.Show("There are no words to build cloud");
                Invoke((MethodInvoker)delegate
                {
                    createCloudButton.Enabled = true;
                    cloudCreateProgress.Value = 0;
                    programStatus.Text = "Error";
                    saveAsToolStripMenuItem.Enabled = false;
                });
                return;
            }
            Invoke((MethodInvoker) delegate
            {
                createCloudButton.Enabled = true;
                pictureBox1.Image = image;
                programStatus.Text = "Done";
                cloudCreateProgress.Value = 0;
                saveAsToolStripMenuItem.Enabled = true;
            });
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newFileDialog = new NewFileForm();
            if (newFileDialog.ShowDialog(this) != DialogResult.OK) return;
            programStatus.Text = "Input text to create";
            var width = newFileDialog.Width;
            var height = newFileDialog.Height;
            dataProvider.ImageSize = new Size(width, height);
            SwitchElementsEnabled(true);
            inputTextBox.Clear();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog(this) != DialogResult.OK) return;
            dataProvider.WordsFont = fontDialog1.Font;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog(this) != DialogResult.OK) return;
            dataProvider.BackGroundColor = backgroundColorDialog.Color;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program easy. You needn't in help");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nikita Bobin");
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorsForm.ShowDialog(this) != DialogResult.OK) return;
            dataProvider.WordsColors = colorsForm.Colors;
        }

        private void wordsCountBar_Scroll(object sender, EventArgs e)
        {
            dataProvider.WordsCount = ((TrackBar)sender).Value;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            programStatus.Text = string.IsNullOrEmpty(inputTextBox.Text) ? "Input text to create" : "Ready to create";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            saveFileDialog1.FileName = $"cloud[{date.Day}_{date.Month}_{date.Year}][{date.Hour}_{date.Minute}_{date.Second}]";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false)).First();
            try
            {
                inputTextBox.Lines = File.ReadAllLines(path);
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }
            catch
            {
                MessageBox.Show("Can not read file");
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                inputTextBox.SelectAll();
        }
    }
}
