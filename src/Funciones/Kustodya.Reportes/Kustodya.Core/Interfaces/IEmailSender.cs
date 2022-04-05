using System.Threading.Tasks;

namespace Kustodya.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}