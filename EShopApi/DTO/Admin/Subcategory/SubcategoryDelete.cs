using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Subcategory;

public class SubcategoryDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
