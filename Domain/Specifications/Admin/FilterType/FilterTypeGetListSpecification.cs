using Ardalis.Specification;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Admin.FilterType;

public class FilterTypeGetListSpecification : Specification<Models.EShop.FilterType, SelectListSpecificationType>
{
    public FilterTypeGetListSpecification()
    {
        var query = Query
            .Select(c => new SelectListSpecificationType
            {
                Value = c.Id,
                Name = c.Name
            }).AsTracking();
    }
}
