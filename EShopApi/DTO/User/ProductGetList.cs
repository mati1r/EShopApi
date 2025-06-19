using Core.DTO.Core;

namespace Application.DTO.User;

public class ProductGetList
{
    public int SubCategoryId { get; set; }
    public AppPaginationList Pagination { get; set; }
    public List<AppFilters>? Filters { get; set; }
    public AppOrderBy OrderBy { get; set; }
}
