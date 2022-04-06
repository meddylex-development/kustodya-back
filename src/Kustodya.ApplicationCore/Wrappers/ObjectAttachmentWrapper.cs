using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Shared.Wrappers
{
    public class ObjectAttachmentWrapper
    {
        public string content { get; set; }
        public string type { get; set; }
        public string filename { get; set; }
        public string disposition { get; set; }
        public string content_id { get; set; }
    }
}
