

using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Admin.Request.Product;

public class ProductPriceChange
{
    [Range(0, int.MaxValue)]
    public int Id { get; set; }

    [Range(0, double.MaxValue)]
    public double Value { get; set; }
}
