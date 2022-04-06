using Kustodya.BussinessLogic.Interfaces.General;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services.AzureBlob
{
    public class BlobService : IBlobService
    {
        private readonly IConfiguration _configuration;
        private CloudStorageAccount _account;
        private CloudBlobClient _client;
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            Configure();
        }

        private void Configure()
        {
             //var connParsed = CloudStorageAccount.TryParse("DefaultEndpointsProtocol=https;AccountName=meddylexdev;AccountKey=BCCE0wITHORzRXnM9dJfjB9nEF4MW50haCKHBdfn6LkTWAuGuvOSpaTy6mFJStHMBR+1lCkCtQy9GrwnSiz33g==;EndpointSuffix=core.windows.net", out CloudStorageAccount account);
            var connParsed = CloudStorageAccount.TryParse("DefaultEndpointsProtocol=https;AccountName=meddylex;AccountKey=sZVLCLJD2yz+h2C9/08tCXDsFJWxx00LZcpJgSPay8EjVCpbgKtVhN2yJxdF8ej0SI7Ng/WttAuMO0L412iXhg==;EndpointSuffix=core.windows.net", out CloudStorageAccount account);
            _account = account;
            _client = _account.CreateCloudBlobClient();

            if (!connParsed)
            {
                throw new BadBlobConnectionStringException();
            }
        }

       

        public async Task<Guid> UploadToBlobAsync(MemoryStream stream, string containerName)
        {
            var blockName = Guid.NewGuid();
            try
            {
                CloudBlobContainer container = _client.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();
                CloudBlockBlob block = container.GetBlockBlobReference(blockName.ToString());
                await block.UploadFromStreamAsync(stream);
            }
            catch (Exception)
            {
                throw new ErrorUploadingStreamException();
            }
            return blockName;
        }

        public async Task<string> UploadToBlobWithNameAsync(MemoryStream stream, string containerName, string name)
        {
            var blockName = Guid.NewGuid();
            try
            {
                CloudBlobContainer container = _client.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();
                CloudBlockBlob block = container.GetBlockBlobReference(blockName.ToString() + "_" + name);
                await block.UploadFromStreamAsync(stream);
            }
            catch (Exception)
            {
                throw new ErrorUploadingStreamException();
            }
            return blockName + "_" + name;
        }

        public async Task<bool> DeleteBlobAsync(string guid)
        {
            CloudBlobContainer container = _client.GetContainerReference("mycontainer");
            var block = container.GetBlockBlobReference(guid);

            return await block.DeleteIfExistsAsync().ConfigureAwait(false);
        }

        public async Task<MemoryStream> GetBlobFileByGuidAsync(string blobId, string containerName)
        {
            CloudBlobContainer container = _client.GetContainerReference(containerName);
            CloudBlockBlob block = container.GetBlockBlobReference(blobId);
            MemoryStream memoryStream = new MemoryStream();
            await block.DownloadToStreamAsync(memoryStream).ConfigureAwait(false);
            return memoryStream;
        }
        public string GetBlobSasUri(string blobId, string containerName) {
            return null;
        }

        //public void CopyStream(Stream input, Stream output)
        //{
        //    if (input == null || output == null)
        //    {
        //        throw new ArgumentNullException("Invalid argument");
        //    }

        //    byte[] buffer = new byte[16 * 1024];
        //    int read;
        //    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //    {
        //        output.Write(buffer, 0, read);
        //    }
        //}

    }

    public class BadBlobConnectionStringException : Exception
    {
        public BadBlobConnectionStringException()
        {

        }
        public BadBlobConnectionStringException(string message) : base(message)
        {
        }

        public BadBlobConnectionStringException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class ErrorUploadingStreamException : Exception
    {
        public ErrorUploadingStreamException()
        {

        }
        public ErrorUploadingStreamException(string message) : base(message)
        {
        }

        public ErrorUploadingStreamException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
