using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.SubcategoryRefProductType;

public class SubcategoryRefProductTypeDelete
{
    [Range(1, int.MaxValue)]
    public int SubcategoryId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }
}
