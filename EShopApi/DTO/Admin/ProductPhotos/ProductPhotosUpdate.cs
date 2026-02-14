using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductPhotos;

public class ProductPhotosUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    public IFormFile Photo { get; set; }
}
