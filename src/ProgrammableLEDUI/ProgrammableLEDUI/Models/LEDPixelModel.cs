using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammableLEDUI.Models
{
    public class LEDPixelModel
    {
        public int PixelIndex { get; set; }
        public Color PixelColor { get; set; }

        public int Column { get; set; }
        public int Row { get; set; }

    }
}
