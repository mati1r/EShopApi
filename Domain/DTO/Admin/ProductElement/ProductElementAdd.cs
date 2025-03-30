using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Admin.ProductElement;

public class ProductElementAdd
{
    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductValueId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
}