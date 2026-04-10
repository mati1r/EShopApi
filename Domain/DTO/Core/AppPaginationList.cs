using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Core;

public class AppPaginationList
{
    [Range(1, int.MaxValue)]
    public int Page { get; set; }

    [Range(1, int.MaxValue)]
    public int PerPage { get; set; }
}
