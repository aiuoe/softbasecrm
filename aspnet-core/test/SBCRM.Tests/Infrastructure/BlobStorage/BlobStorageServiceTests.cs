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
    /// Tests suite for Blob storage service
    /// </summary>
    public class BlobStorageServiceTests : AppTestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="testOutputHelper"></param>
        public BlobStorageServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Upload file - infrastructure perspective (without tenant and root folder concerns)
        /// </summary>
        /// <param name="uploadFilePath"></param>
        /// <param name="blobContainer"></param>
        /// <param name="blobDirectory"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("C:\\SB\\Files\\logo.png", "softbase-erp-dev", "tenants\\1\\company", "logo.png")]
        [InlineData("C:\\SB\\Files\\logo.png", "softbase-erp-dev", "tenants\\1\\company", "")]
        public async Task UploadFileBlob_WithAutoTenantInjection_ReturnsBlobUri(string uploadFilePath, string blobContainer, string blobDirectory, string blobName)
        {
            // Arrange
            var fileBlobDto = new UploadCloudBlobFileDto
            {
                File = await File.ReadAllBytesAsync(uploadFilePath),
                ContainerName = blobContainer,
                DirectoryName = blobDirectory,
                FileName = blobName,
                ContentType = GetContentType(uploadFilePath)
            };

            // Act
            var blobUri = await Resolve<IBlobStorageService>().UploadBlobFile(fileBlobDto);
            _testOutputHelper.WriteLine("Blob file uri: {0}", blobUri);

            // Assert
            Assert.NotNull(blobUri);
        }

        /// <summary>
        /// Get blob file
        /// </summary>
        /// <param name="blobContainer"></param>
        /// <param name="blobName"></param>
        /// <param name="resultFilePath"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("softbase-erp-dev", "tenants\\1\\company\\logo.png", "C:\\SB\\Files")]
        public async Task GetBlobFile_WithValidParameters_ReturnsBlob(string blobContainer, string blobName, string resultFilePath)
        {
            // Arrange
            var fileName = blobName.Split("\\").Last();
            var outputPath = Path.Combine(resultFilePath, fileName);
            FileInfo fileInfo = null;

            // Act
            DownloadCloudBlobFileDto blobFile = await Resolve<IBlobStorageService>().GetBlobFile(blobContainer, blobName);

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
