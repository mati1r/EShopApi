using Ardalis.Specification;
using Core.SpecificationTypes.Admin.ProductElement;

namespace Core.Specifications.Admin.ProductElement;

public class ProductElementGetListSpecification : Specification<Models.EShop.ProductElement, ProductElementGetListSpecificationType>
{
    public ProductElementGetListSpecification(int productId)
    {
        var query = Query
            .Select(pe => new ProductElementGetListSpecificationType
            {
                Id = pe.Id,
                ProductId = pe.ProductId,
                ProductTypeId = pe.ProductTypeId,
                ProductTypeName = pe.ProductType.Name,
                ProductValueId = pe.ProductValueId,
                ProductValueName = pe.ProductValue.Name,
                ProductTypeFilterId = pe.ProductType.FilterTypeId
            })
            .Where(pe => pe.ProductId == productId)
            .AsTracking();
    }
}
