using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Admin.ProductValue;

public class ProductValueAdd
{
    [MaxLength(200)]
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }
}
