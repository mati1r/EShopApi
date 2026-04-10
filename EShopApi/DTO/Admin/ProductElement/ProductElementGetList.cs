using System.ComponentModel.DataAnnotations;
using Core.DTO.Core;

namespace Application.DTO.Admin.ProductElement;

public class ProductElementGetList
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    public AppPaginationList Pagination { get; set; }
    public AppOrderBy OrderBy { get; set; }
}
