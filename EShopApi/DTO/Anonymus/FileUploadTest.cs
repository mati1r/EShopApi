using Application.Helpers.Attributes;

namespace Application.DTO.Anonymus;

public class FileUploadTest
{
    public string FilePath { get; set; }

    [FileSize(5 * 1024 * 1024)] // 5 MB
    public IFormFile File { get; set; }
}
