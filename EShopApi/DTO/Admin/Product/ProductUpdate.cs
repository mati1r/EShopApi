using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Product;

public class ProductUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int? SubcategoryId { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public int? Quantity { get; set; }
}
