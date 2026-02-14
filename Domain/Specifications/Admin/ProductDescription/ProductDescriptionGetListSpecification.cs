using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums;
using Core.SpecificationTypes.Admin.ProductDescription;

namespace Core.Specifications.Admin.ProductDescription;

public class ProductDescriptionGetListSpecification : Specification<Models.EShop.ProductDescriptions, ProductDescriptionGetListSpecificationType>
{
    public ProductDescriptionGetListSpecification(int productId, AppOrderBy orderBy, bool deleted)
    {
        Expression<Func<Models.EShop.ProductDescriptions, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductDescriptionOrderBy.Description => p => p.Description,
            (int)ProductDescriptionOrderBy.Id => p => p.Id,
            _ => p => p.Id
        };

        var query = Query
            .Select(p => new ProductDescriptionGetListSpecificationType
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Description = p.Description
            }).Where(p => p.ProductId == productId && p.Deleted == deleted);


        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) query.OrderBy(orderByExpression);
        if (orderBy.OrderDirection == OrderDirectionEnum.Desc) query.OrderByDescending(orderByExpression);

        query.AsTracking();
    }
}
