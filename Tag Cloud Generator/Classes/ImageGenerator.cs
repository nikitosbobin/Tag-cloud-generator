using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class ImageGenerator : ICloudImageGenerator
    {
        public Bitmap CreateImage(ITagCloud cloud, Color backgroundColor, List<Color> wordsBrushes = null)
        {
            var image = new Bitmap(cloud.CloudSize.Width, cloud.CloudSize.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                SetGraphics(graphics, backgroundColor);
                var words = cloud.Words
                    .OrderByDescending(w => w.Frequency)
                    .ToArray();
                DrawAllWords(graphics, words, cloud, wordsBrushes);
                graphics.ResetTransform();
            }
            return image;
        }

        private void DrawAllWords(Graphics graphics, IWordBlock[] words, ITagCloud cloud, List<Color> wordsBrushes)
        {
            foreach (var word in words)
            {
                DrawWord(word, graphics, wordsBrushes == null || wordsBrushes.Count == 0 
                    ? GetGrayGradation(word.Frequency, words.First().Frequency) 
                    : wordsBrushes.GetRandomElement(), cloud);
            }
        }

        private void DrawWord(IWordBlock word, Graphics graphics, Color color, ITagCloud cloud)
        {
            var graphicsState = graphics.Save();
            graphics.TranslateTransform(word.Location.X, word.Location.Y);
            var angle = word.IsVertical ? 270f : 0f;
            graphics.RotateTransform(angle);
            graphics.DrawString(word.Source, cloud.FontsCache.GetFont(word.FontSize), new SolidBrush(color), 0, 0);
            graphics.Restore(graphicsState);
        }

        private Color GetGrayGradation(int currentFrequency, int maxFrequency)
        {
            var t = currentFrequency / (double) maxFrequency;
            if (t < 0.3) t = 0.3;
            var targetGradation = 256 - (int) (t*255);
            return Color.FromArgb(targetGradation, targetGradation, targetGradation);
        }

        private void SetGraphics(Graphics graphics, Color backgroundColor)
        {
            graphics.Clear(backgroundColor);
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }
    }
}
