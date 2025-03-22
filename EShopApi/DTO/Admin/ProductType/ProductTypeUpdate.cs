using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductType;

public class ProductTypeUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int FilterTypeId { get; set; }
}
