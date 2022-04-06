using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class TranscripcionConfirmationModel
    {
        public long IdPaciente { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombrePaciente { get; set; }
        public string ValorIncapacidad { get; set; }
        public long IdTranscripcion { get; set; }
        public long IdIncapacidad { get; set; }
    }
}
