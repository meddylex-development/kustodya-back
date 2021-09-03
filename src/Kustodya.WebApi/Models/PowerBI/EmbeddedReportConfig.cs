using Microsoft.PowerBI.Api.Models;
using System;

namespace Kustodya.WebApi.Models
{
    public class EmbeddedReportConfig
    {
        public string EmbedURL { get; set; }
        public DateTime? Expiration { get; set; }
        public string GroupID { get; set; }
        public Report ReportData { get; set; }
        public string ReportID { get; set; }
        public string Token { get; set; }
        public string TokenID { get; set; }
    }
}