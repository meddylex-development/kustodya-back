using System.Threading.Tasks;
using Kustodya.WebApi.Models.K2Conceptos;

namespace Kustodya.WebApi.Services
{
    public interface IMailService
    {
        Task SendEmailNotification(MailRequest mailRequest);
    }
}
