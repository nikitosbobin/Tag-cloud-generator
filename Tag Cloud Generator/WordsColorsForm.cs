using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator
{
    public partial class WordsColorsForm : Form
    {
        public List<Color> Colors
        {
            get
            {
                return colorsListView.Items
                    .Cast<ListViewItem>()
                    .Select(i => i.Text.ToColor())
                    .ToList();
            }
        }

        public WordsColorsForm()
        {
            InitializeComponent();
            colorsListView.SmallImageList = new ImageList();

        }

        private void addColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) != DialogResult.OK) return;
            colorsListView.SmallImageList.Images.Add(GetImage(colorDialog1.Color));
            colorsListView.Items.Add(colorDialog1.Color.ToHtmlColor(), colorsListView.SmallImageList.Images.Count - 1);
        }

        private void deleteColorButton_Click(object sender, EventArgs e)
        {
            var selected = colorsListView.Items.SelectedItems();
            foreach (var itemIndex in selected.OrderByDescending(d => d))
                colorsListView.Items.RemoveAt(itemIndex);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private Bitmap GetImage(Color color)
        {
            var result = new Bitmap(10, 10);
            var graphics = Graphics.FromImage(result);
            graphics.Clear(color);
            graphics.Dispose();
            return result;
        }
    }
}
