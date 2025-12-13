using Core.DTO.Core;

namespace Application.Helpers;

public static class FileHelper
{
    public static async Task<FileModel> ConvertIFormFileToFileModelAsync(IFormFile file)
    {
        var fileModel = new FileModel();
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            fileModel.Content = stream.ToArray();
            fileModel.FileExtension = Path.GetExtension(file.FileName);
            fileModel.FileName = Path.GetFileNameWithoutExtension(file.FileName);
        }
        return fileModel;
    }
}
