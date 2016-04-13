using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public ImageGenerator(int width, int height)
        {
            ImageSize = new Size(width, height);
        }

        public Bitmap CreateImage(ICloudGenerator cloud, Font wordsFont, Color backgroundColor, List<Color> wordsBrushes = null)
        {
            var image = new Bitmap(ImageSize.Width, ImageSize.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                SetGraphics(graphics, backgroundColor);
                words = cloud.CreateCloud(graphics, wordsFont).Words.OrderByDescending(w => w.Frequency).ToArray();
                DrawAllWords(wordsBrushes);
                graphics.ResetTransform();
            }
            return image;
            
        }

        private void DrawAllWords(List<Color> wordsBrushes)
        {
            foreach (var word in words)
            {
                word.Draw(wordsBrushes == null || wordsBrushes.Count == 0 
                    ? GetGrayGradation(word) 
                    : wordsBrushes.GetRandomElement());
            }
        }

        private Color GetGrayGradation(WordBlock word)
        {
            var better = words.First();
            var t = word.Frequency / (double)better.Frequency;
            if (t < 0.3) t = 0.3;
            return ConvertToColor(0, (byte)(t * 255), 255);
        }

        private static Color ConvertToColor(byte r, byte g, byte b)
        {
            var rString = r.ToHtmlColor();
            var gString = g.ToHtmlColor();
            var bString = b.ToHtmlColor();
            var totalHtmlColor = $"#{rString}{gString}{bString}";
            return totalHtmlColor.ToColor();
        }

        private void SetGraphics(Graphics graphics, Color backgroundColor)
        {
            var imageCenter = ImageSize.Center();
            graphics.Transform = new Matrix(1, 0, 0, 1, imageCenter.X, imageCenter.Y);
            graphics.Clear(backgroundColor);
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }
    }
}
