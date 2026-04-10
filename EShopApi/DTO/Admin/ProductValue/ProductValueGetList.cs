using System.ComponentModel.DataAnnotations;
using Core.DTO.Core;

namespace Application.DTO.Admin.ProductValue;

public class ProductValueGetList
{
    [Range(1, int.MaxValue)]
    public int ProductTypeId { get; set; }
    public AppPaginationList Pagination {  get; set; }
    public AppOrderBy OrderBy { get; set; }
}
