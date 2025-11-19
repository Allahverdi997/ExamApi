using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstraction.Service.Core
{
    public interface IFileCloudStorageService
    {
        public Task<string> UploadAsync([FromForm] IFormFile file);
        public Task<Stream> DownloadAsync(string fileName, string containerName);
        public Task<bool> DeleteAsync(string fileName, string containerName);
        public Task<List<string>> GetNames(string containerName);
        //public async Task<IActionResult> GetLogAsync(string fileName);
        //public async Task<IActionResult> SetLogAsync(string text, string fileName);
    }
}
