namespace SBCRM.Blob.Dto
{
    /// <summary>
    /// Download blob file DTO
    /// </summary>
    public class DownloadCloudBlobFileDto
    {
        public byte[] File { get; set; }
        public string ContentType { get; set; }
    }
}
