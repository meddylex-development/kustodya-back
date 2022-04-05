using System.Threading.Tasks;

namespace Kustodya.Core.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}