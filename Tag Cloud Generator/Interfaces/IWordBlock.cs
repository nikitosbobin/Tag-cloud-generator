using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    interface IWordBlock
    {
        string Source { get; }
        int Frequency { get; }
        Point Location { get; }
        float FontSize { get; set; }
        bool IsVertical { get; set; }
    }
}
