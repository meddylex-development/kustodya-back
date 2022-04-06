using System.Threading.Tasks;

namespace Kustodya.Core.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}