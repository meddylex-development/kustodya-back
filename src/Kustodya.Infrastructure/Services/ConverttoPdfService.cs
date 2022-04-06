using DinkToPdf;
using DinkToPdf.Contracts;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Infrastructure.Services
{
    public class ConverttoPdfService : IConverttoPdfService
    {
        private readonly IConverter _converter;
        public ConverttoPdfService(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] ConvertHtmltoPDF(string html, string nombreArchivo)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 5, Right = 5 },
                DocumentTitle = nombreArchivo
                //Out = string.Format(filePath, endfilename)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 12, Right = "", Line = false },
                FooterSettings = { FontName = "Arial", FontSize = 12, Line = false, Right = "Page [page] of [toPage]", Left = "", Center = "" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
                
            };

            byte[] result = _converter.Convert(pdf);
            return result;
        }
    }
}
