using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductDescription;

public class ProductDescriptionAdd
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    public string Descriptions { get; set; }
}
