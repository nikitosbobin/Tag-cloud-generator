using System.Drawing;
using System.Drawing.Imaging;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        Size ImageSize { get; }
        void CreateImage(ICloudGenerator cloud, string path, ImageFormat format);
    }
}
