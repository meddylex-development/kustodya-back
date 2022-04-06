using System.Threading.Tasks;

namespace Kustodya.Core.Reportes.Services
{
    public interface IAadService
    {
        Task<string> GetTokenAadAsync();
    }
}