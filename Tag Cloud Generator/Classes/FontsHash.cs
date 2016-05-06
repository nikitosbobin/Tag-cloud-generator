using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class FontsHash : IDisposable
    {
        public FontsHash()
        {
            fontsHash = new HashSet<Font>();
        }



        private readonly HashSet<Font> fontsHash;
        public void Dispose()
        {
            foreach (var font in fontsHash)
                font.Dispose();
        }
    }
}
