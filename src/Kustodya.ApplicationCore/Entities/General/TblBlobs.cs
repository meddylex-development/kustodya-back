using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblBlobs
    {
        public string Id { get; set; }
        public string MimeType { get; set; }
        public DateTime? Year { get; set; }
        public string OriginalName { get; set; }
        public string Creator { get; set; }
        public int FileType { get; set; }

        public virtual TblTiposArchivo FileTypeNavigation { get; set; }
    }
}
