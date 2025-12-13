namespace Core.IServices.Infrastructure;

public interface IStorageService
{
    public Task Upload(string filePath, string contentBody);
    public Task Upload(string filePath, byte[] byteArray);
    public Task<string> DownloadBase64();
}
