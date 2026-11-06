using System.ComponentModel.DataAnnotations;
using Core.DTO.Admin.Request.Product;

namespace Application.DTO.Admin.Product;

public class ProductUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int? SubcategoryId { get; set; }
    public string? Name { get; set; }
    public int? Quantity { get; set; }
    public List<ProductPriceChange> PricesToChange { get; set; } = [];
}
