using Core.DTO.Core;

namespace Application.DTO.Anonymus;

public class ProductGetList
{
    public int SubCategoryId { get; set; }
    public AppPaginationList Pagination { get; set; }
    public List<AppFilters>? Filters { get; set; }
    public AppOrderBy OrderBy { get; set; }
    public bool Deleted { get; set; }
}
