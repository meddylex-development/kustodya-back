using System;
using System.IO;
using System.Threading.Tasks;

namespace Kustodya.BussinessLogic.Interfaces.General
{
    public interface IBlobService
    {
        Task<Guid> UploadToBlobAsync(MemoryStream stream, string containerName);
        Task<bool> DeleteBlobAsync(string guid);
        Task<MemoryStream> GetBlobFileByGuidAsync(string blobId, string containerName);
        string GetBlobSasUri(string blobId, string containerName);
        Task<string> UploadToBlobWithNameAsync(MemoryStream stream, string containerName, string name);
    }
}