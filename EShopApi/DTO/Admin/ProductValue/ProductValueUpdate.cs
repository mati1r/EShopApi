using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductValue;

public class ProductValueUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }
}
