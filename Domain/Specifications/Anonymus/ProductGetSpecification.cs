using Ardalis.Specification;
using Core.Models.EShop;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Anonymus;

public class ProductGetSpecification : Specification<Product, ProductGetListSpecificationType>
{
    public ProductGetSpecification(int id, bool deleted)
    {

        var query = Query
            .Select(p => new ProductGetListSpecificationType
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Descriptions = p.ProductDescriptions.Where(pd => pd.Deleted == false).Select(pd => pd.Description).ToList(),
                ProductPhotosName = p.ProductPhotos.Where(pp => pp.Deleted == false).Select(pp => pp.GeneratedName).ToList(),
                ProductElements = p.ProductElements
                    .Select(pe => new ProductElementListSpecificationType
                    {
                        Id = pe.Id,
                        ProductValueId = pe.ProductValueId,
                        ProductValueName = pe.ProductValue.Name,
                        ProductTypeId = pe.ProductTypeId,
                        ProductTypeName = pe.ProductType.Name,
                        ProductTypeFilterId = pe.ProductType.FilterTypeId,
                        ProductTypeFilterName = pe.ProductType.Name
                    })
                    .ToList()
            }).Where(p => p.Id == id && p.Deleted == deleted).
            AsTracking();
    }
}
