using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductDescription;

public class ProductDescriptionUpdate : ProductDescriptionAdd
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
