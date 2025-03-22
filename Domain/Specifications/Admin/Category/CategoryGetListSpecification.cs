using Ardalis.Specification;
using Core.SpecificationTypes.Admin.Category;

namespace Core.Specifications.Admin.Category;

public class CategoryGetListSpecification : Specification<Models.EShop.Category, CategoryGetListSpecificationType>
{
    public CategoryGetListSpecification()
    {
        var query = Query
            .Select(c => new CategoryGetListSpecificationType
            {
                Id = c.Id,
                Name = c.Name
            }).AsTracking();
    }
}
