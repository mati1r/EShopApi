using Core.DTO.Core;

namespace Application.DTO.Admin.Product;

public class ProductPricesGetList
{
    public int ProductId { get; set; }
    public AppPaginationList Pagination { get; set; }
    public AppOrderBy OrderBy { get; set; }
    public bool Deleted { get; set; }
}
