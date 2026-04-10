using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.ProductElement;

namespace Core.Specifications.Admin.ProductElement;

public class ProductElementGetListSpecification : Specification<Models.EShop.ProductElement, ProductElementGetListSpecificationType>
{
    public ProductElementGetListSpecification(int productId, AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.ProductElement, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductElementOrderByEnum.ProductId => pe => pe.ProductId,
            (int)ProductElementOrderByEnum.ProductTypeId => pe => pe.ProductTypeId,
            (int)ProductElementOrderByEnum.ProductTypeName => pe => pe.ProductType.Name,
            (int)ProductElementOrderByEnum.ProductValueId => pe => pe.ProductValueId,
            (int)ProductElementOrderByEnum.ProductValueName => pe => pe.ProductValue.Name,
            (int)ProductElementOrderByEnum.ProductTypeFilterId => pe => pe.ProductType.FilterTypeId,
            (int)ProductElementOrderByEnum.Id => pe => pe.Id,
            _ => pe => pe.Id
        };

        Query
            .Select(pe => new ProductElementGetListSpecificationType
            {
                Id = pe.Id,
                ProductId = pe.ProductId,
                ProductTypeId = pe.ProductTypeId,
                ProductTypeName = pe.ProductType.Name,
                ProductValueId = pe.ProductValueId,
                ProductValueName = pe.ProductValue.Name,
                ProductTypeFilterId = pe.ProductType.FilterTypeId
            })
            .Where(pe => pe.ProductId == productId)
            .AsNoTracking();

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
