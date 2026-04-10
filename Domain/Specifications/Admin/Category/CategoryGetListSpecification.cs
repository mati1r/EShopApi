using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.Category;

namespace Core.Specifications.Admin.Category;

public class CategoryGetListSpecification : Specification<Models.EShop.Category, CategoryGetListSpecificationType>
{
    public CategoryGetListSpecification(AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.Category, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)CategoryOrderByEnum.Name => c => c.Name,
            (int)CategoryOrderByEnum.Id => c => c.Id,
            _ => c => c.Id
        };

        Query
            .Select(c => new CategoryGetListSpecificationType
            {
                Id = c.Id,
                Name = c.Name
            });

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
