using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTareas
{
    class Enums
    {
    }
    public enum OCRExtractionMethod : int
    {
        Tesseract = 1,
        IBMWatson = 2,
        Azure = 3,
        Google_VisionAI = 4,
        iTextSharp = 5,
        Word = 6
    }
}
