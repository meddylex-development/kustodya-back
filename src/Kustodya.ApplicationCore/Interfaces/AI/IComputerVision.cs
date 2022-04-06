using Kustodya.ApplicationCore.Dtos.Incapacidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.AI
{
    public interface IComputerVision
    {
        Task<OCRExtractionMethodModel> ReadPrintedTextAsync(MemoryStream stream, string uuid);
    }
}
