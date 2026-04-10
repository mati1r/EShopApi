using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Subcategory;

public class SubcategoryUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
