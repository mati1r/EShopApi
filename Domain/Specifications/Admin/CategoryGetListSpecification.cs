using Ardalis.Specification;
using Core.SpecificationTypes.Admin.Category;
using EShopApi.Models.EShop;

namespace Core.Specifications.Admin;

public class CategoryGetListSpecification : Specification<Category, CategoryGetListSpecificationType>
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
