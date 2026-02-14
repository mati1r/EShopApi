using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductDescription;

public class ProductDescriptionDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
