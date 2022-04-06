using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services
{
    public class FileHelper : IFileHelper
    {
        public async Task<bool> TrySaveFile(IFormFile file, string filepath)
        {
            try
            {
                if (file.Length > 0)
                    using (var stream = new FileStream(filepath, FileMode.Create))
                        await file.CopyToAsync(stream);
            }
            catch (Exception e)
            {
                throw e;
                //return false; 
            }
            return true;
        }


#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string GetFileName(IFormFile file, out string ext)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            ext = Path.GetExtension(file.FileName);
            string guid = Guid.NewGuid().ToString();
            return guid + ext;
        }

        public string EnsureDirectory(string fileName, string relativePath)
        {
            if (!Directory.Exists(relativePath))
                Directory.CreateDirectory(relativePath);
            var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), relativePath,
                  fileName);
            return filePath;
        }

    }
}
