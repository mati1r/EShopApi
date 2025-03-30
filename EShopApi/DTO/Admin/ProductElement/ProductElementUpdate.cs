using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductElement;

public class ProductElementUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductValueId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
}
