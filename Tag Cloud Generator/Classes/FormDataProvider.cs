using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_Cloud_Generator.Classes
{
    class FormDataProvider
    {
        public Font WordsFont { get; set; }
        public Color BackGroundColor { get; set; }
        public List<Color> WordsColors { get; set; }
        public int WordsCount { get; set; }
    }
}
