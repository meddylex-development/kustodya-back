using Kustodya.BussinessLogic.Interfaces.General;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.BussinessLogic.Services
{
    public class BlobService : IBlobService
    {
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            Configure();
        }

        private void Configure()
        {
            var connParsed = CloudStorageAccount.TryParse(_configuration.GetConnectionString("AzureStorage"), out CloudStorageAccount account);
            _account = account;
            _client = _account.CreateCloudBlobClient();

            if (!connParsed)
            {
                throw new BadBlobConnectionStringException();
            }
        }

        private readonly IConfiguration _configuration;
        private CloudStorageAccount _account;
        private CloudBlobClient _client;

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

        public string GetBlobSasUri(string guid, string containernName)
        {
            //Get a reference to container
            CloudBlobContainer container = _client.GetContainerReference(containernName);

            //Get a reference to a blob within the container.
            CloudBlockBlob blob = container.GetBlockBlobReference(guid);

            //Upload text to the blob. If the blob does not yet exist, it will be created.
            //If the blob does exist, its existing content will be overwritten.
            /*string blobContent = "This blob will be accessible to clients via a Shared Access Signature.";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
            ms.Position = 0;
            using (ms)
            {
                blob.UploadFromStream(ms);
            }*/

            //Set the expiry time and permissions for the blob.
            //In this case the start time is specified as a few minutes in the past, to mitigate clock skew.
            //The shared access signature will be valid immediately.
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(15);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;// | SharedAccessBlobPermissions.Write;

            //Generate the shared access signature on the blob, setting the constraints directly on the signature.
            string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);

            //Return the URI string for the container, including the SAS token.
            return blob.Uri + sasBlobToken;
        }

        public async Task<string> UploadToBlobWithNameAsync(MemoryStream stream, string containerName, string name)
        {
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
