using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class WordBlock
    {
        public WordBlock(Font font, KeyValuePair<string, int> wordFrequency) 
            : this(font, wordFrequency.Key, wordFrequency.Value) { }

        public WordBlock(Font font, string source, int frequency = 1)
        {
            Source = source;
            Frequency = frequency;
            Location = Point.Empty;
            var rnd = new Random(DateTime.Now.Millisecond);
            IsVertical = rnd.Next(0, 2) == 1;
            IsVertical = false;
            savedLocations = new Stack<Point>();
            Font = font;
        }
        
        public string Source { get; set; }
        public int Frequency { get; set; }
        public Point Location { get; private set; }

        public Font Font { get; set; }

        public float FontSize
        {
            get { return Font.Size; }
            set { Font = Font.SetSize(value); }
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
    }
}
