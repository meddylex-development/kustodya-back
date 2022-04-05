using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.Shared.Wrappers;
//using Kustodya.BusinessLogic.Services.Configuracion.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.MedicosService.Services
{
    public class EmailServiceStub : IEmailService
    {
        public bool SendEmail(SendgridEmailWrapper sendgridWrapper) => throw new System.NotImplementedException();
        public Task<bool> SendEmailAsync(string email, string template, Dictionary<string, string> templateData)
        {
            return Task.Run(() => true);
        }

        public Task<bool> SendEmailListAsync(IReadOnlyList<string> emails, string template, Dictionary<string, string> templateData)
        {
            return Task.Run(() => true);
        }
    }
}