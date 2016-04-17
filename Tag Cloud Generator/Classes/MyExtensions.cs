using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace Tag_Cloud_Generator.Classes
{
    static class RectangleExtensions
    {
        public static Point MultipleTo(this Point source, int constant)
        {
            source.X *= constant;
            source.Y *= constant;
            return source;
        }

        public static double Perimetr(this Rectangle source)
        {
            return 2 * (source.Width + source.Height);
        }

        public static Point RigthBottom(this Rectangle source)
        {
            return new Point(source.Right, source.Bottom);
        }

        public static Point LeftBottom(this Rectangle source)
        {
            return new Point(source.Left, source.Bottom);
        }

        public static Point RightTop(this Rectangle source)
        {
            return new Point(source.Right, source.Top);
        }

        public static Point[] GetPoints(this Rectangle source)
        {
            return new[] { source.Location, source.RightTop(), source.RigthBottom(), source.LeftBottom() };
        }
    }

    static class StringExtensions
    {
        public static Size Measure(this string source, Graphics graphics, Font font)
        {
            var measureString = graphics.MeasureString(source, font);
            return new Size((int)measureString.Width, (int)measureString.Height);
        }

        public static Color ToColor(this string source)
        {
            var converter = new ColorConverter();
            var colorObj = converter.ConvertFromString(source);
            if (colorObj == null)
                throw new NotSupportedException($"can not convert color {source}");
            return (Color)colorObj;
        }
    }

    static class ByteExtensions
    {
        public static string ToHtmlColor(this byte source)
        {
            var result = Convert.ToString(source, 16);
            if (result.Length > 2)
                throw new NotSupportedException($"Input {source} to base 16: {result} is not valid to HTML format");
            if (result.Length == 1)
                result = "0" + result;
            return result;
        }
    }

    static class PointExtensions
    {
        public static Point OffsetTo(this Point p1, Point p2)
        {
            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;
            return new Point(dx, dy);
        }
    }

    static class CollectionsExtensions
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public static int[] SelectedItems(this ListView.ListViewItemCollection source)
        {
            return source
                .Cast<ListViewItem>()
                .Where(item => item.Selected)
                .Select(i => i.Index)
                .ToArray();
        }

        public static TSource GetRandomElement<TSource>(this List<TSource> source)
        {
            return source.ElementAt(Random.Next(0, source.Count));
        }

        public static IList<TSource> Shuffle<TSource>(this IList<TSource> source)
        {
            var n = source.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Next(n + 1);
                var value = source[k];
                source[k] = source[n];
                source[n] = value;
            }
            return source;
        }

        public static double GetMiddle<TSource>(this IEnumerable<TSource> source, Func<TSource, int> elementLabda)
        {
            var sourseAtArray = source as TSource[] ?? source.ToArray();
            if (sourseAtArray.Length == 0) return 0d;
            var allSum = sourseAtArray.Sum(elementLabda);
            return allSum / (double)sourseAtArray.Length;
        }

        public static TSource[] OffsetArray<TSource>(this TSource[] source, int offset)
        {
            var result = new List<TSource>();
            for (var i = 0; i < source.Length; ++i)
            {
                result.Add(source[offset % source.Length]);
                offset++;
            }
            return result.ToArray();
        }

        public static WordBlock[] UpdateGraphics(this WordBlock[] source, Graphics graphics)
        {
            foreach (var word in source)
                word.Graphics = graphics;
            return source;
        }
    }

    static class SizeExtensions
    {
        public static Point Center(this Size source)
        {
            return new Point(source.Width / 2, source.Height / 2);
        }
    }

    static class ColorExtensions
    {
        public static string ToHtmlColor(this Color source)
        {
            return $"#{source.R.ToHtmlColor()}{source.G.ToHtmlColor()}{source.B.ToHtmlColor()}";
        }
    }
}
