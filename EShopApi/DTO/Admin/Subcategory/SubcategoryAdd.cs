using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Subcategory;

public class SubcategoryAdd
{
    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
