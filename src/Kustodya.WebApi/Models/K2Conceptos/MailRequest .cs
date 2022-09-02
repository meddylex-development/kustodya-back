using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string html { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
