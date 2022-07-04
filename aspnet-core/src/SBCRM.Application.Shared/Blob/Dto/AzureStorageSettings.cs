namespace SBCRM.Blob.Dto
{
    /// <summary>
    /// Azure storage settings DTO
    /// </summary>
    public class AzureStorageSettings
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
        public string RootDirectory { get; set; }
    }
}
