using System;
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
        public Size ImageSize { get; set; }
        private WordBlock[] words;

        public Bitmap CreateImage(ICloudGenerator cloud, Color backgroundColor, List<Color> wordsBrushes = null)
        {
            var image = new Bitmap(ImageSize.Width, ImageSize.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                SetGraphics(graphics, backgroundColor);
                words = cloud.Words
                    .UpdateGraphics(graphics)
                    .OrderByDescending(w => w.Frequency)
                    .ToArray();
                DrawAllWords(wordsBrushes);
                graphics.ResetTransform();
            }
            return image;
        }

        public Bitmap CreateImage(ICloudGenerator cloud, FormDataProvider data, Action<int> setProgress = null)
        {
            return CreateImage(cloud, setProgress, data.WordsFont, data.WordsCount,
                data.FirstScale,data.BackGroundColor,data.WordsColors);
        }

        public Bitmap CreateImage(ICloudGenerator cloud, Action<int> setProgress, Font wordsFont, 
            int wordsCount, int firstScale, Color backgroundColor, List<Color> wordsBrushes = null)
        {
            var image = new Bitmap(ImageSize.Width, ImageSize.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                SetGraphics(graphics, backgroundColor);
                words = cloud.CreateCloud(graphics, wordsFont, wordsCount, firstScale, setProgress).Words
                    .OrderByDescending(w => w.Frequency)
                    .ToArray();
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
            var targetGradation = 256 - (int) (t*255);
            return Color.FromArgb(targetGradation, targetGradation, targetGradation);
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
