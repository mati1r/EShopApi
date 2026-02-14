using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Product;

public class ProductGet
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    public bool Deleted { get; set; }
}
