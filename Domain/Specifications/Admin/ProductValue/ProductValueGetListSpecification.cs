using Ardalis.Specification;
using Core.SpecificationTypes.Admin.ProductValue;

namespace Core.Specifications.Admin.ProductValue;

public class ProductValueGetListSpecification : Specification<Models.EShop.ProductValue, ProductValueGetListSpecificationType>
{
    public ProductValueGetListSpecification(int productTypeId)
    {
        var query = Query
            .Select(pv => new ProductValueGetListSpecificationType
            {
                Id = pv.Id,
                Name = pv.Name,
                Value = pv.Value,
            })
            .Where(pv => pv.ProductTypeId == productTypeId)
            .AsTracking();
    }
}
