using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Services
{
    public interface IFileHelper
    {
        string EnsureDirectory(string fileName, string relativePath);
        string GetFileName(IFormFile file, out string ext);
        Task<bool> TrySaveFile(IFormFile file, string filepath);
    }
}