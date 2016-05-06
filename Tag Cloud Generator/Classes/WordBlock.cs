using System;
using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class WordBlock : IWordBlock
    {
        public class Comparer : IEqualityComparer<IWordBlock>
        {
            public bool Equals(IWordBlock x, IWordBlock y)
            {
                if (x == y) return true;
                if (x == null || y == null) return false;
                return x.Source == y.Source && x.Frequency == y.Frequency
                    && Math.Abs(x.FontSize - y.FontSize) < double.Epsilon;
            }

            public int GetHashCode(IWordBlock word)
            {
                if (word == null) return 0;
                return word.FontSize.GetHashCode() ^ word.Frequency.GetHashCode() ^ word.Source.GetHashCode();
            }
        }

        public WordBlock(float fontSize, KeyValuePair<string, int> wordFrequency) 
            : this(fontSize, wordFrequency.Key, wordFrequency.Value) { }

        public WordBlock(float fontSize, string source, int frequency = 1)
        {
            Source = source;
            Frequency = frequency;
            Location = Point.Empty;
            var rnd = new Random(DateTime.Now.Millisecond);
            IsVertical = rnd.Next(0, 2) == 1;
            IsVertical = false;
            savedLocations = new Stack<Point>();
            FontSize = fontSize;
        }
        
        public string Source { get; }
        public int Frequency { get; }
        public Point Location { get; private set; }
        public float FontSize { get; set; }
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

        public WordBlock OffsetOn(int offsetX, int offsetY)
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
            return MoveToPoint(new Point(positionX, positionY));
        }

        public override string ToString()
        {
            return $"{Source}--{Frequency}";
        }
    }
}
