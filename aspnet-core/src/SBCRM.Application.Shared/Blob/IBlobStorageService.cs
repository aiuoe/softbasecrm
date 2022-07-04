using System.Threading.Tasks;
using SBCRM.Blob.Dto;

namespace SBCRM.Blob
{
    /// <summary>
    /// Cloud blob storage interface
    /// </summary>
    public interface IBlobStorageService
    {
        /// <summary>
        /// Get blob file
        /// This method handles exceptions and returns null on failure.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns>
        /// The method returns a object with the metadata information of the file
        /// </returns>
        Task<DownloadCloudBlobFileDto> GetBlobFile(string containerName, string blobName);

        /// <summary>
        /// Upload blob file
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// The method returns the URI to access the file
        /// </returns>
        Task<string> UploadBlobFile(UploadCloudBlobFileDto input);
    }
}