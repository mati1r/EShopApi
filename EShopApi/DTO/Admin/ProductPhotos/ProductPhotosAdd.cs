using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductPhotos;

public class ProductPhotosAdd
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    public IFormFile Photo { get; set; }
}
