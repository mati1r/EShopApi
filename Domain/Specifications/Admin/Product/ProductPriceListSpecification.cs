using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.Models.EShop;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Admin.Product;

public class ProductPriceListSpecification : Specification<ProductPrice, ProductPriceListSpecificationType>
{
    public ProductPriceListSpecification(int productId, AppOrderBy orderBy, bool deleted)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        Expression<Func<ProductPrice, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductPriceOrderByEnum.Value => p => p.Value,
            (int)ProductPriceOrderByEnum.DateFrom => p => p.DateFrom,
            (int)ProductPriceOrderByEnum.DateTo => p => p.DateTo ?? DateOnly.MaxValue,
            _ => p => p.Id
        };

        Query
            .Select(p => new ProductPriceListSpecificationType
            {
                Id = p.Id,
                Value = p.Value,
                DateFrom = currentDate,
                DateTo = currentDate,
            }).Where(p => p.ProductId == productId && p.Deleted == deleted);

  

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
