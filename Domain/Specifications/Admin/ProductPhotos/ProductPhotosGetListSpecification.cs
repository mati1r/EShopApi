using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.ProductPhotos;

namespace Core.Specifications.Admin.ProductPhotos;

public class ProductPhotosGetListSpecification : Specification<Models.EShop.ProductPhotos, ProductPhotosGetListSpecificationType>
{
    public ProductPhotosGetListSpecification(int productId, AppOrderBy orderBy, bool deleted)
    {
        Expression<Func<Models.EShop.ProductPhotos, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)ProductPhotosDirectionOrderByEnum.ProductId => p => p.ProductId,
            (int)ProductPhotosDirectionOrderByEnum.FileName => p => p.FileName,
            (int)ProductPhotosDirectionOrderByEnum.Extenstion => p => p.Extenstion,
            (int)ProductPhotosDirectionOrderByEnum.Id => p => p.Id,
            _ => p => p.Id
        };

        Query
            .Select(p => new ProductPhotosGetListSpecificationType
            {
                Id = p.Id,
                ProductId = p.ProductId,
                FileName = p.FileName,
                Extension = p.Extenstion,
            }).Where(p => p.ProductId == productId && p.Deleted == deleted);


        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
