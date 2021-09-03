using Kustodya.ApplicationCore.Interfaces.Configuracion.CodigoQR;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.BusinessLogic.Services.Configuracion.CodigoQR
{
    public class CodigoQRService : ICodigoQRService
    {
        public string GenerateCodeQR(string data)
        {
            var imgType= Base64QRCode.ImageType.Jpeg;
            var qrImgSrc = "";
            using (QRCodeGenerator qRCodeGenerator = new QRCodeGenerator())
            {
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode("http://www.google.com", QRCodeGenerator.ECCLevel.Q);
                using (Base64QRCode base64QRCode = new Base64QRCode(qRCodeData))
                {
                    var qrCodeImageAsBase64 = base64QRCode.GetGraphic(50, Color.Black, Color.White, true, imgType);
                    qrImgSrc = String.Format(CultureInfo.InvariantCulture, "data:image/jpg;base64,{0}", qrCodeImageAsBase64);
                }
            }

            return qrImgSrc;
        }
}
}
