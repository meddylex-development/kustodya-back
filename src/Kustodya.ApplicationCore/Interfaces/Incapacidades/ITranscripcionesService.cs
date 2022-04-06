using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Dtos.Incapacidades;

namespace Kustodya.ApplicationCore.Interfaces.Incapacidades
{
    public interface ITranscripcionesService
    {
        Task<TranscripcionConfirmationModel> AddTranscription(TranscripcionModel transcripcionModel);
        Task<TranscripcionConfirmationModel> AddTranscriptionOnlyOcr(TranscripcionModel transcripcionModel);
    }
}
