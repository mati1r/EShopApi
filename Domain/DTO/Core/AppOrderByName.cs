using Core.Enums.Common;

namespace Core.DTO.Core;

public class AppOrderByName
{
    public OrderDirectionEnum OrderDirection { get; set; }
    public string? OrderByName { get; set; }
}
