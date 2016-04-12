using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class ImageGenerator : ICloudImageGenerator
    {
        public Size ImageSize { get; }
        private WordBlock[] words;
        private readonly List<SolidBrush> wordsBrushes;

        //шрифты еще надо почистить
        private string fontFamily;
        public string FontFamily
        {
            get
            {
                if (string.IsNullOrEmpty(fontFamily))
                    fontFamily = "Times New Roman";
                return fontFamily;
            }
            set { fontFamily = value; }
        }

        public ImageGenerator(int width, int height, List<SolidBrush> colors = null)
        {
            wordsBrushes = colors == null || colors.Count == 0 
                ? new List<SolidBrush> { new SolidBrush(Color.White) } 
                : colors;
            ImageSize = new Size(width, height);
        }

        public void CreateImage(ICloudGenerator cloud, string path, ImageFormat format)
        {
            using (var image = new Bitmap(ImageSize.Width, ImageSize.Height))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    SetGraphics(graphics);
                    words = cloud.CreateCloud(graphics).Words.OrderByDescending(w => w.Frequency).ToArray();
                    DrawAllWords();
                    graphics.ResetTransform();
                }
                image.Save(path, format);
            }
        }

        private void DrawAllWords()
        {
            foreach (var word in words)
            {
                if (wordsBrushes.Count == 1 && wordsBrushes.First().Color == Color.White)
                    word.Draw(GetGrayGradation(word));
                else
                    word.Draw(wordsBrushes.GetRandomElement());
            }
        }

        private SolidBrush GetGrayGradation(WordBlock word)
        {
            var better = words.First();
            var t = word.Frequency / (double)better.Frequency;
            if (t < 0.3) t = 0.3;
            return new SolidBrush(ConvertToColor(0, (byte)(t * 255), 255));
        }

        private static Color ConvertToColor(byte r, byte g, byte b)
        {
            var rString = r.ToHtmlColor();
            var gString = g.ToHtmlColor();
            var bString = b.ToHtmlColor();
            var totalHtmlColor = $"#{rString}{gString}{bString}";
            return totalHtmlColor.ToColor();
        }

        private void SetGraphics(Graphics graphics)
        {
            var imageCenter = ImageSize.Center();
            graphics.Transform = new Matrix(1, 0, 0, 1, imageCenter.X, imageCenter.Y);
            graphics.Clear("#000000".ToColor());
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }
    }
}
