using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.FilterType;

public class FilterTypeUpdate
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
}
