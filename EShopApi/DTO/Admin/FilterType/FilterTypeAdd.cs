using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.FilterType;

public class FilterTypeAdd
{
    [MaxLength(100)]
    public string Name { get; set; }
}
