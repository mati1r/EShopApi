using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Admin.Subcategory;

namespace Core.Specifications.Admin.Subcategory;

public class SubcategoryGetListSpecification : Specification<Models.EShop.Subcategory, SubcategoryGetListSpecificationType>
{
    public SubcategoryGetListSpecification(int categoryId, AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.Subcategory, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)SubcategoryOrderByEnum.Name => c => c.Name,
            (int)SubcategoryOrderByEnum.Id => c => c.Id,
            _ => c => c.Id
        };

        Query
            .Select(s => new SubcategoryGetListSpecificationType{ 
                Id = s.Id, 
                Name = s.Name 
            }).Where(s => s.CategoryId == categoryId);

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
