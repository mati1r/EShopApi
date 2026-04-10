using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums.Common;
using Core.Enums.OrderBy;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Admin.FilterType;

public class FilterTypeGetListSpecification : Specification<Models.EShop.FilterType, SelectListSpecificationType>
{
    public FilterTypeGetListSpecification(AppOrderBy orderBy)
    {
        Expression<Func<Models.EShop.FilterType, object?>> orderByExpression = orderBy.OrderBy switch
        {
            (int)FilterTypeOrderByEnum.Name => ft => ft.Name,
            (int)FilterTypeOrderByEnum.Value => ft => ft.Id,
            _ => ft => ft.Id
        };

        Query
            .Select(ft => new SelectListSpecificationType
            {
                Value = ft.Id,
                Name = ft.Name
            });

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) Query.OrderBy(orderByExpression);
        else if (orderBy.OrderDirection == OrderDirectionEnum.Desc) Query.OrderByDescending(orderByExpression);

        Query.AsNoTracking();
    }
}
