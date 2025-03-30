using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductValue;

public class ProductValueDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
