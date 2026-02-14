using Ardalis.Specification;
using Core.SpecificationTypes.Admin.ProductDescription;

namespace Core.Specifications.Admin.ProductDescription;

public class ProductDescriptionGetSpecification : Specification<Models.EShop.ProductDescriptions, ProductDescriptionGetListSpecificationType>
{
    public ProductDescriptionGetSpecification(int id)
    {
        var query = Query
            .Select(pd => new ProductDescriptionGetListSpecificationType
            {
                Id = pd.Id,
                ProductId = pd.ProductId,
                Description = pd.Description
            }).Where(pd => pd.Deleted == false && pd.Id == id).AsTracking();
    }
}
