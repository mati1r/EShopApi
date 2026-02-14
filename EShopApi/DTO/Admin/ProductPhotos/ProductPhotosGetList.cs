using Core.DTO.Core;

namespace Application.DTO.Admin.ProductPhotos;

public class ProductPhotosGetList
{
    public int ProductId { get; set; }
    public AppPaginationList Pagination { get; set; }
    public AppOrderBy OrderBy { get; set; }
    public bool Deleted { get; set; }
}
