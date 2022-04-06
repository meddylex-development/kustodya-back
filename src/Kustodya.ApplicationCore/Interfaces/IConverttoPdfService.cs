using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IConverttoPdfService
    {
        byte[] ConvertHtmltoPDF(string html, string nombreArchivo);
    }
}
