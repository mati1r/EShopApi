using Ardalis.Specification;
using Core.SpecificationTypes.Admin.ProductType;

namespace Core.Specifications.Admin.ProductType;

public class ProductTypeGetListSpecification : Specification<Models.EShop.ProductType, ProductTypeGetListSpecificationType>
{
    public ProductTypeGetListSpecification()
    {
        var query = Query
            .Select(c => new ProductTypeGetListSpecificationType
            {
                Id = c.Id,
                FilterTypeId = c.FilterTypeId,
                Name = c.Name
            }).AsTracking();
    }
}
