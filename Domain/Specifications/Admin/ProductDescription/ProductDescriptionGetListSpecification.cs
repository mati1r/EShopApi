using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.ProductDescription;

namespace Core.Specifications.Admin.ProductDescription;

public class ProductDescriptionGetListSpecification : Specification<Models.EShop.ProductDescriptions, ProductDescriptionGetListSpecificationType>
{
    public ProductDescriptionGetListSpecification(int productId, AppOrderBy orderBy, bool deleted)
    {
        Expression<Func<Models.EShop.ProductDescriptions, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductDescriptionOrderByEnum.Description => p => p.Description,
            (int)ProductDescriptionOrderByEnum.Id => p => p.Id,
            _ => p => p.Id
        };

        Query
            .Select(p => new ProductDescriptionGetListSpecificationType
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Description = p.Description
            }).Where(p => p.ProductId == productId && p.Deleted == deleted);


        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
