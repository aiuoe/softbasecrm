using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.Extensions.Options;
using SBCRM.Blob;
using SBCRM.Blob.Dto;

namespace SBCRM.Infrastructure.BlobStorage
{
    /// <summary>
    /// Application storage service implementation
    /// </summary>
    public class ApplicationStorageService : ApplicationService, IApplicationStorageService
    {
        private readonly AzureStorageSettings _storageSettings;
        private readonly IBlobStorageService _blobStorageService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="blobStorageService"></param>
        /// <param name="storageSettings"></param>
        public ApplicationStorageService(
            IBlobStorageService blobStorageService,
            IOptions<AzureStorageSettings> storageSettings)
        {
            _blobStorageService = blobStorageService;
            _storageSettings = storageSettings.Value;
        }

        /// <summary>
        /// Get blob file.
        /// In this method the container name is internally loaded
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns>
        /// The method returns a object with the metadata information of the file
        /// </returns>
        public async Task<DownloadCloudBlobFileDto> GetBlobFile(string blobName)
        {
            return await _blobStorageService.GetBlobFile(_storageSettings.ContainerName, blobName);
        }

        /// <summary>
        /// Upload blob file.
        /// Within this method the tenantId is injected into the root folder of the container
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <returns>
        /// The method returns the URI to access the file
        /// </returns>
        public async Task<string> UploadBlobFile(string directory, byte[] file, string fileName, string contentType)
        {
            var rootDirectory = string.Format(_storageSettings.RootDirectory, AbpSession?.TenantId);
            var fileBlobDto = new UploadCloudBlobFileDto
            {
                File = file,
                ContainerName = _storageSettings.ContainerName,
                DirectoryName = Path.Combine(rootDirectory, directory),
                FileName = fileName,
                ContentType = contentType
            };
            return await _blobStorageService.UploadBlobFile(fileBlobDto);
        }
    }
}
