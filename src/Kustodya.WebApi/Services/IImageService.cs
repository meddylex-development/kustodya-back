using System.IO;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services
{
    public interface IImageService
    {
        
        Task<MemoryStream> ConvertToTiff(MemoryStream stream);
        Task<MemoryStream> ConvertToPpm(MemoryStream stream);
    }
}