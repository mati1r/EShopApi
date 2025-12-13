namespace Infrastracture.Storage;

public class S3StorageConfig
{
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string AuthenticationRegion { get; set; }
    public string BucketName { get; set; }
    public string ServiceURL { get; set; }
    public bool ForcePathStyle { get; set; }
}
