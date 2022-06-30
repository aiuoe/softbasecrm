namespace SBCRM.Blob.Dto
{
    /// <summary>
    /// Upload blob file DTO
    /// </summary>
    public class UploadCloudBlobFileDto
    {
        public byte[] File { get; set; }
        public string FilePath { get; set; }
        public string DirectoryName { get; set; }
        public string ContainerName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
