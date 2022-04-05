using Kustodya.Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Configuracion.Email
{
    public interface IEmailService
    {
        bool SendEmail(SendgridEmailWrapper sendgridWrapper);
        Task<bool> SendEmailAsync(string email, string template, Dictionary<string,string> templateData);
        Task<bool> SendEmailListAsync(IReadOnlyList<string> emails, string template, Dictionary<string, string> templateData);
    }
}