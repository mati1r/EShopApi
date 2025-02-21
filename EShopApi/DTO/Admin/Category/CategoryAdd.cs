using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Category;

public class CategoryAdd
{
    [MaxLength(100)]
    public string Name { get; set; }
}
