using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
        public MainForm()
        {
            InitializeComponent();
            colorsListView.SmallImageList = new ImageList();
            textHandler = new SimpleTextHandler();
            decoder = new TxtDecoder();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var openFileDialog = sender as OpenFileDialog;
                if (openFileDialog == null)
                {
                    MessageBox.Show($"Something wrong");
                    return;
                }
                var path = openFileDialog.FileName;
                inputTextBox.Lines = File.ReadAllLines(path);
            }
            catch
            {
                MessageBox.Show($"Can not read file");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        
        private void deleteColorButton_Click(object sender, EventArgs e)
        {
            var selected = colorsListView.Items.SelectedItems();
            foreach (var itemIndex in selected.OrderByDescending(d => d))
                colorsListView.Items.RemoveAt(itemIndex);
        }

        private void addColorButton_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog(this);
            if (result != DialogResult.OK) return;
            colorsListView.SmallImageList.Images.Add(GetImage(colorDialog1.Color));
            colorsListView.Items.Add(colorDialog1.Color.ToHtmlColor(), colorsListView.SmallImageList.Images.Count - 1);
        }

        private Bitmap GetImage(Color color)
        {
            var result = new Bitmap(10, 10);
            var graphics = Graphics.FromImage(result);
            graphics.Clear(color);
            graphics.Dispose();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = fontDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            fontLabel.Text = fontDialog1.Font.Name;
        }

        private void createCloudButton_Click(object sender, EventArgs e)
        {
            decoder.TextLines = inputTextBox.Lines;
            if (decoder.TextLines.Length == 0)
            {
                MessageBox.Show("There are no words to build cloud");
                return;
            }
            var colors = colorsListView.Items
                .Cast<ListViewItem>()
                .Select(i => new SolidBrush(i.Text.ToColor()))
                .ToList();
            imageGenerator = new ImageGenerator((int) imageWidth.Value, (int) imageHeight.Value, colors);
            cloudGenerator = new RelativeChoiceCloud(decoder, textHandler, imageGenerator, this);
            asyncCloudCreator.RunWorkerAsync();
        }

        private void asyncCloudCreator_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker) delegate
            {
                createCloudButton.Enabled = false;
            });
            var image = imageGenerator.CreateImage(cloudGenerator);
            MessageBox.Show("Cloud created");
            Invoke((MethodInvoker)delegate
            {
                createCloudButton.Enabled = true;
                pictureBox1.Image = image;
            });
        }

        private void inputTextBox_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
