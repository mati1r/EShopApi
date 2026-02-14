using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums;
using Core.SpecificationTypes.Admin.ProductPhotos;

namespace Core.Specifications.Admin.ProductPhotos;

public class ProductPhotosGetListSpecification : Specification<Models.EShop.ProductPhotos, ProductPhotosGetListSpecificationType>
{
    public ProductPhotosGetListSpecification(int productId, AppOrderBy orderBy, bool deleted)
    {
        Expression<Func<Models.EShop.ProductPhotos, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductPhotosDirectionOrderBy.ProductId => p => p.ProductId,
            (int)ProductPhotosDirectionOrderBy.FileName => p => p.FileName,
            (int)ProductPhotosDirectionOrderBy.Extenstion => p => p.Extenstion,
            (int)ProductPhotosDirectionOrderBy.Id => p => p.Id,
            _ => p => p.Id
        };

        var query = Query
            .Select(p => new ProductPhotosGetListSpecificationType
            {
                Id = p.Id,
                ProductId = p.ProductId,
                FileName = p.FileName,
                Extension = p.Extenstion,
            }).Where(p => p.ProductId == productId && p.Deleted == deleted);


        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) query.OrderBy(orderByExpression);
        if (orderBy.OrderDirection == OrderDirectionEnum.Desc) query.OrderByDescending(orderByExpression);

        query.AsTracking();
    }
}
