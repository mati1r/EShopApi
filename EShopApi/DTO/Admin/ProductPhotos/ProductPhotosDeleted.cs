using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductPhotos;

public class ProductPhotosDeleted
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
