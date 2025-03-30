using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductElement;

public class ProductElementGetList
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
}
