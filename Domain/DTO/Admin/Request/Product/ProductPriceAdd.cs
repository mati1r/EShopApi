using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Admin.Request.Product;

public class ProductPriceAdd
{
    public DateOnly DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }

    [Range(0, double.MaxValue)]
    public double Value { get; set; }   
}
