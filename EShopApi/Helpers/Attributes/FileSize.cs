using System.ComponentModel.DataAnnotations;

namespace Application.Helpers.Attributes;

public class FileSizeAttribute(int maxFileSize) : ValidationAttribute
{
    private readonly int _maxFileSize = maxFileSize;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            if (file.Length > _maxFileSize)
            {
                return new ValidationResult($"File size should not exceed {_maxFileSize} bytes.");
            }
        }

        if (value is IEnumerable<IFormFile> files)
        {
            foreach (var f in files)
            {
                if (f.Length > _maxFileSize)
                    return new ValidationResult($"One of files exceed max size of {_maxFileSize} bytes.");
            }
        }

        return ValidationResult.Success;
    }
}
