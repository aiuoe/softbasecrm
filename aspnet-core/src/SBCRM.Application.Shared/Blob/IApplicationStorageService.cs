using System.Threading.Tasks;
using SBCRM.Blob.Dto;

namespace SBCRM.Blob
{
    /// <summary>
    /// Application storage interface
    /// </summary>
    public interface IApplicationStorageService
    {
        /// <summary>
        /// Get blob file.
        /// In this method the container name is internally loaded
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns>
        /// The method returns a object with the metadata information of the file
        /// </returns>
        Task<DownloadCloudBlobFileDto> GetBlobFile(string blobName);

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
        Task<string> UploadBlobFile(string directory, byte[] file, string fileName, string contentType);
    }
}