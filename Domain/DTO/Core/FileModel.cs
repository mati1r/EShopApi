namespace Core.DTO.Core;

public class FileModel
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] Content { get; set; }
}
