using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.ProductValue;

namespace Core.Specifications.Admin.ProductValue;

public class ProductValueGetListSpecification : Specification<Models.EShop.ProductValue, ProductValueGetListSpecificationType>
{
    public ProductValueGetListSpecification(int productTypeId, AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.ProductValue, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductValueOrderByEnum.Value => p => p.Value,
            (int)ProductValueOrderByEnum.Name => p => p.Name,
            (int)ProductValueOrderByEnum.Id => p => p.Id,
            _ => p => p.Id
        };

        Query
            .Select(pv => new ProductValueGetListSpecificationType
            {
                Id = pv.Id,
                Name = pv.Name,
                Value = pv.Value,
            })
            .Where(pv => pv.ProductTypeId == productTypeId);


        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
