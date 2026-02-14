using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductDescription;

public class ProductDescriptionGet
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
