using Microsoft.AspNetCore.Mvc;

namespace Application.Concrete.Service
{
    public class FileCloudStorageService //: IFileCloudStorageService
    {
        //readonly ICloudStorage BlobStorage;
        //public IAppSetting AppSetting { get; set; }
        //public FileCloudStorageService(ICloudStorage blobStorage, IAppSetting appSetting)
        //{
        //    BlobStorage = blobStorage;
        //    AppSetting = appSetting;
        //}

        //public async Task<bool> DeleteAsync(string fileName, string containerName)
        //{
        //    try
        //    {
        //        await BlobStorage.DeleteAsync(fileName, containerName);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<Stream> DownloadAsync(string fileName, string containerName)
        //{
        //    try
        //    {
        //        Stream stream = await BlobStorage.DownloadAsync(fileName, containerName);
        //        return stream;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<string>> GetNames(string containerName)
        //{
        //    return BlobStorage.GetNames(containerName);
        //}

        //public async Task<string> UploadAsync([FromForm] IFormFile file)
        //{
        //    try
        //    {
        //        string _file = file.FileName + Guid.NewGuid().ToString();

        //        using (var ms = new MemoryStream())
        //        {
        //            await file.CopyToAsync(ms);
        //            ms.Seek(0, SeekOrigin.Begin);
        //            await BlobStorage.UploadAsnyc(ms, _file, "files");
        //        }

        //        return AppSetting.CloudStorageUrl + AppSetting.FileContainer + "/" + _file;
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
