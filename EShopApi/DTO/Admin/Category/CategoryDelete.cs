using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.Category;

public class CategoryDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
