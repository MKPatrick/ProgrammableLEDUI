using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammableLEDUI.Models
{
    [Serializable]
    public class LEDPixelModel
    {
        public int PixelIndex { get; set; }
        public Color PixelColor { get; set; }

    }
}
