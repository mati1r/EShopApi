using Core.DTO.Core;

namespace Application.DTO.User.History;

public class HistoryGetList
{
    public AppPaginationList Pagination { get; set; }
    public AppOrderByName OrderBy { get; set; }
}
