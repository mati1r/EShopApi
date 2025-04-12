using Core.Enums;

namespace Core.DTO.Core;

public class AppFilters
{
    public FilterTypeEnum FilterTypeId { get; set; }
    public List<int>? FilterValueIds { get; set; }
    public int? FilterRangeMin { get; set; }
    public int? FilterRangeMax { get; set; }
}
