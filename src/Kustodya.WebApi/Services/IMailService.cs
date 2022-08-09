using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.WebApi.Models.K2Conceptos;

namespace Kustodya.WebApi.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
