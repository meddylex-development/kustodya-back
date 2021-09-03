using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public sealed class TranscripcionesSpec : BaseSpec<TblTranscripciones>
    {
        public TranscripcionesSpec(string uuid)
              : base(u => u.TblobId == uuid)
        {
        }
    }
}
