using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class OCRExtractionMethodModel
    {
        public IList<string> Sentences { get; set; }
        public string RawOcrResponse { get; set; }
    }
}
