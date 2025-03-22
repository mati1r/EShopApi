using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductType;

public class ProductTypeAdd
{
    [MaxLength(100)]
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int FilterTypeId { get; set; }
}
