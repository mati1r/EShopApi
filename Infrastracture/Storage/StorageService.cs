using Amazon.S3;
using Amazon.S3.Model;
using Core.IServices.Infrastructure;
using Microsoft.Extensions.Options;

namespace Infrastracture.Storage;

public class StorageService : IStorageService
{
    private readonly AmazonS3Client _client;
    private readonly S3StorageConfig _config;
    private readonly string _bucketName;

    public StorageService(IOptions<S3StorageConfig> config)
    {
        _config = config.Value;
        _bucketName = _config.BucketName;

        var clientConfig = new AmazonS3Config
        {
            ServiceURL = _config.ServiceURL,
            ForcePathStyle = _config.ForcePathStyle,
            AuthenticationRegion = _config.AuthenticationRegion
        };

        _client = new AmazonS3Client(_config.AccessKey, _config.SecretKey, clientConfig);
    }

    public async Task Upload(string filePath, string contentBody)
    {
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath,
            ContentBody = contentBody
        };

        await _client.PutObjectAsync(request);
    }

    public async Task Upload(string filePath, byte[] byteArray)
    {
        var stream = new MemoryStream();
        await stream.WriteAsync(byteArray);

        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath,
            InputStream = stream
        };

        await _client.PutObjectAsync(request);
    }

    public async Task<string> DownloadBase64(string filePath, CancellationToken cancellationToken = default) {
        var request = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath,
        };

        using var response = await _client.GetObjectAsync(request, cancellationToken);
        using var responseStream = response.ResponseStream;
        using var memoryStream = new MemoryStream();
        await responseStream.CopyToAsync(memoryStream);
        return Convert.ToBase64String(memoryStream.ToArray());
    }

    public async Task<byte[]> DownloadBytes(string filePath, CancellationToken cancellationToken = default)
    {
        var request = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath,
        };

        using var response = await _client.GetObjectAsync(request, cancellationToken);
        using var responseStream = response.ResponseStream;
        using var memoryStream = new MemoryStream();
        await responseStream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
