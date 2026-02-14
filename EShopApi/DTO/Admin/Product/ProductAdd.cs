using System.ComponentModel.DataAnnotations;
using Application.Helpers.Attributes;

namespace Application.DTO.Admin.Product;

public class ProductAdd
{
    [Range(1, int.MaxValue)]
    public int SubcategoryId { get; set; }
    public string Name { get; set; }
    public List<string> Descriptions { get; set; } = [];

    [FileSize(5 * 1024 * 1024)]
    public List<IFormFile> Photos { get; set; } = [];
    public double Price { get; set; }
    public int Quantity { get; set; }
}
