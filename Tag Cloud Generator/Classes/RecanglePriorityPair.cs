using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class RecanglePriorityPair
    {
        public RecanglePriorityPair(Rectangle rect)
        {
            Rect = rect;
            Priority = 1;
        }

        public Rectangle Rect { get; }
        public int Priority { get; set; }
    }
}
