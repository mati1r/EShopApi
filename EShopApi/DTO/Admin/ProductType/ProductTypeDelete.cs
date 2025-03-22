using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductType;

public class ProductTypeDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
