using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using SBCRM.Blob;
using SBCRM.Blob.Dto;

namespace SBCRM.Infrastructure.BlobStorage
{
    /// <summary>
    /// Azure blob storage implementation
    /// </summary>
    public class AzureBlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly ILogger<AzureBlobStorageService> _logger;

        public AzureBlobStorageService(
            BlobServiceClient blobServiceClient, 
            ILogger<AzureBlobStorageService> logger)
        {
            _blobServiceClient = blobServiceClient;
            _logger = logger;
        }

        /// <summary>
        /// Get blob file.
        /// This method handles exceptions and returns null on failure.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns>
        /// The method returns a object with the metadata information of the file
        /// </returns>
        public async Task<DownloadCloudBlobFileDto> GetBlobFile(string containerName, string blobName)
        {
            try
            {
                BlobContainerClient containerClient = await GetBlobContainerClientByName(containerName, createIfNotExist: false);
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                var downloadAsync = await blobClient.DownloadContentAsync();

                return new DownloadCloudBlobFileDto
                {
                    File = downloadAsync.Value.Content.ToArray(),
                    ContentType = downloadAsync.GetRawResponse().Headers.ContentType
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error on GetBlobFile -> ", e);
                return null;
            }
        }

        /// <summary>
        /// Upload blob file
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// The method returns the URI to access the file
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<string> UploadBlobFile(UploadCloudBlobFileDto input)
        {
            BlobContainerClient containerClient = await GetBlobContainerClientByName(input.ContainerName);
            input.FileName = GetFileName(input);
            BlobClient blobClient = containerClient.GetBlobClient(Path.Combine(input.DirectoryName, input.FileName));

            await using (Stream stream = new MemoryStream(input.File))
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders
                {
                    ContentType = input.ContentType
                });
            }

            return blobClient.Uri.AbsoluteUri;
        }

        private static string GetFileName(UploadCloudBlobFileDto inputUploadCloudBlobFile)
        {
            return string.IsNullOrEmpty(inputUploadCloudBlobFile.FileName)
                ? Guid.NewGuid().ToString()
                : inputUploadCloudBlobFile.FileName.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Get blob container client by name (create if not exists)
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="accessType"></param>
        /// <param name="createIfNotExist"></param>
        /// <returns></returns>
        private async Task<BlobContainerClient> GetBlobContainerClientByName(
            string containerName,
            PublicAccessType accessType = PublicAccessType.None,
            bool createIfNotExist = true)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            if (createIfNotExist && !(await blobContainerClient.ExistsAsync()).Value)
            {
                await _blobServiceClient.CreateBlobContainerAsync(containerName, accessType);
            }

            return blobContainerClient;
        }
    }
}