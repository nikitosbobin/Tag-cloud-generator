using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tag_Cloud_Generator.Classes
{
    class WordBlock
    {
        public static WordBlock Clone(WordBlock source)
        {
            return new WordBlock(source.Graphics, source.Source, source.Frequency);
        }

        public class Comparer : IEqualityComparer<WordBlock>
        {
            public bool Equals(WordBlock x, WordBlock y)
            {
                if (x == y) return true;
                if (x == null || y == null)
                    return false;
                return x.Source == y.Source && x.Frequency == y.Frequency;
            }

            public int GetHashCode(WordBlock obj)
            {
                if (obj == null)
                    return 0;
                return obj.Source.GetHashCode() ^ obj.Frequency;
            }
        }

        public WordBlock(Graphics graphics, string source, int frequency = 1)
        {
            Graphics = graphics;
            Source = source;
            Frequency = frequency;
            Location = Point.Empty;
            var rnd = new Random(DateTime.Now.Millisecond);
            IsVertical = rnd.Next(0, 2) == 1;
            //IsVertical = false;
            savedLocations = new Stack<Point>();
        }

        public Graphics Graphics { get; }
        public string Source { get; set; }
        public int Frequency { get; set; }
        public Point Location { get; private set; }

        public Rectangle GetWordRectangle()
        {
            var currentWordSize = GetWordSize();
            var wordWidth = currentWordSize.Width;
            var wordHeight = currentWordSize.Height;
            var location = new Point(Location.X, Location.Y);
            if (IsVertical) location.Y -= wordWidth;
            return new Rectangle(location, new Size(IsVertical ? wordHeight : wordWidth, IsVertical ? wordWidth : wordHeight));
        }

        public Size GetWordSize()
        {
            return Source.Measure(Graphics, Font);
        }

        private Font font;
        public Font Font
        {
            get { return font ?? (font = new Font("Times New Roman", 12f)); }
            set { font = value; }
        }

        public float FontSize
        {
            get { return Font.Size; }
            set { Font = new Font(Font.FontFamily.ToString(), value); }
        }

        public bool IsVertical { get; set; }
        private readonly Stack<Point> savedLocations;

        public WordBlock SaveLocation()
        {
            savedLocations.Push(Location);
            return this;
        }

        public bool RestoreLocation()
        {
            if (savedLocations.Count == 0) return false;
            Location = savedLocations.Pop();
            return true;
        }

        public bool IntersectsWith(IEnumerable<Rectangle> frames)
        {
            return frames?.Any(r => r.IntersectsWith(GetWordRectangle())) ?? false;
        }

        public WordBlock StayInCenterOfImage()
        {
            var center = GetWordSize().Center();
            MoveToPoint(center.MultipleTo(-1));
            IsVertical = false;
            return this;
        }

        public bool InsideImage()
        {
            return GetWordRectangle().GetPoints().All(Graphics.IsVisible);
        }

        public double Perimetr()
        {
            return GetWordRectangle().Perimetr();
        }

        public WordBlock MoveOn(int offsetX, int offsetY)
        {
            Location = new Point(Location.X + offsetX, Location.Y + offsetY);
            return this;
        }

        public WordBlock MoveToPoint(Point targetLocation)
        {
            Location = targetLocation;
            return this;
        }

        public WordBlock MoveToPoint(int positionX, int positionY)
        {
            Location = new Point(positionX, positionY);
            return this;
        }

        public override string ToString()
        {
            return $"{Source}--{Frequency}";
        }

        public void Draw(Brush brush)
        {
            //Graphics.DrawRectangle(new Pen(Color.Blue), Location.X, Location.Y, 2, 2);
            var grState = Graphics.Save();
            Graphics.TranslateTransform(Location.X, Location.Y);
            var angle = IsVertical ? 270f : 0f;
            Graphics.RotateTransform(angle);
            Graphics.DrawString(Source, Font, brush, 0, 0);
            Graphics.Restore(grState);
            //var v = GetWordRectangle(Graphics);
            //Graphics.DrawRectangle(new Pen(Color.Crimson), v);
        }
    }
}
