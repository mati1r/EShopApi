using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Category;

public class CategoryUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
}
