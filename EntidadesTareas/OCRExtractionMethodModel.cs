using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesTareas
{
    public class OCRExtractionMethodModel
    {
        public IList<string> Sentences { get; set; }
        public string RawOcrResponse { get; set; }
    }
}
