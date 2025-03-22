using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.FilterType;

public class FilterTypeDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
