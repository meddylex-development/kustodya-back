using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Models.SpeechToText
{
    public class UploadFileModel
    {
        public IFormFile file { get; set; }
        public string tFileName { get; set; }
    }
}