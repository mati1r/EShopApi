using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductPhotos;

public class ProductPhotosGet
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
