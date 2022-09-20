using System.Threading.Tasks;
using Kustodya.WebApi.Models.K2Conceptos;

namespace Kustodya.WebApi.Services
{
    public interface IMailService
    {
        //Task SendEmail(MailRequest mailRequest);
        Task SendEmailConcepto(MailRequest mr);

    }
}
