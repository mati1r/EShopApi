using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.ProductType;

namespace Core.Specifications.Admin.ProductType;

public class ProductTypeGetListSpecification : Specification<Models.EShop.ProductType, ProductTypeGetListSpecificationType>
{
    public ProductTypeGetListSpecification(AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.ProductType, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductTypeOrderByEnum.FilterTypeId => p => p.FilterTypeId,
            (int)ProductTypeOrderByEnum.Name => p => p.Name,
            (int)ProductTypeOrderByEnum.Id => p => p.Id,
            _ => p => p.Id
        };

        Query
            .Select(pt => new ProductTypeGetListSpecificationType
            {
                Id = pt.Id,
                FilterTypeId = pt.FilterTypeId,
                Name = pt.Name
            });

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
