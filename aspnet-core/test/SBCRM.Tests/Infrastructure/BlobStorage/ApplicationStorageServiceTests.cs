using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SBCRM.Blob;
using SBCRM.Blob.Dto;
using Xunit;
using Xunit.Abstractions;

namespace SBCRM.Tests.Infrastructure.BlobStorage
{
    /// <summary>
    /// Tests suite for Application storage service
    /// </summary>
    public class ApplicationStorageServiceTests : AppTestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="testOutputHelper"></param>
        public ApplicationStorageServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Upload file - application perspective (tenant and root folder concerns)
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="blobDirectory"></param>
        /// <param name="blobName"></param>
        /// <param name="uploadFilePath"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(1, "company\\subfolder-x\\", "filefromunittest-x.png", "C:\\SB\\Files\\logo.png")]
        public async Task UploadFileBlob_WithAutoTenantInjection_ReturnsBlobUri(
            int tenantId, string blobDirectory, string blobName, string uploadFilePath)
        {
            // Arrange
            UsingTenantId(tenantId);
            var fileToUpload = await File.ReadAllBytesAsync(uploadFilePath);
            var contentType = GetContentType(uploadFilePath);

            // Act
            var blobUri = await Resolve<IApplicationStorageService>()
                .UploadBlobFile(blobDirectory, fileToUpload, blobName, contentType);

            _testOutputHelper.WriteLine("Blob file uri: {0}", blobUri);

            // Assert
            Assert.NotNull(blobUri);
        }


        /// <summary>
        /// Get blob file - application perspective (container concerns)
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="resultFilePath"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("tenants\\1\\company\\subfolder-x\\filefromunittest-x.png", "C:\\SB\\Files")]
        public async Task GetBlobFile_WithValidParameters_ReturnsBlob(string blobName, string resultFilePath)
        {
            // Arrange
            var fileName = blobName.Split("\\").Last();
            var outputPath = Path.Combine(resultFilePath, fileName);
            FileInfo fileInfo = null;

            // Act
            DownloadCloudBlobFileDto blobFile = await Resolve<IApplicationStorageService>().GetBlobFile(blobName);

            if (blobFile != null)
            {
                await File.WriteAllBytesAsync(outputPath, blobFile.File);
                fileInfo = new FileInfo(outputPath);
            }

            // Assert
            Assert.NotNull(blobFile);
            Assert.NotNull(fileInfo);
        }
    }
}
