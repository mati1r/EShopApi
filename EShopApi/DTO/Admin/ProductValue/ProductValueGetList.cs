using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductValue;

public class ProductValueGetList
{
    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }
}
