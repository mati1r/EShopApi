using Core.Enums.Common;

namespace Core.DTO.Core;

public class AppOrderBy
{
    public OrderDirectionEnum OrderDirection { get; set; }
    public int OrderBy { get; set; }
}
