using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tag_Cloud_Generator.Classes
{
    static class RectangleExtensions
    {
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

        public static TSource[] RandomOffsetArray<TSource>(this TSource[] source)
        {
            return source.OffsetArray(Random.Next(0, source.Length));
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
    }

    static class SizeExtensions
    {
        public static Point Center(this Size source)
        {
            return new Point(source.Width / 2, source.Height / 2);
        }
    }
}
