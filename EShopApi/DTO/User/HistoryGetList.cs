using Core.DTO.Core;

namespace Application.DTO.User;

public class HistoryGetList
{
    public AppPaginationList Pagination { get; set; }
    public AppOrderByName OrderBy { get; set; }
}
