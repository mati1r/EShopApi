using Ardalis.Specification;
using Core.Models.EShop;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Anonymus;

public class ProductGetSpecification : Specification<Product, ProductGetListSpecificationType>
{
    public ProductGetSpecification(int id, bool deleted)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var query = Query
            .Select(p => new ProductGetListSpecificationType
            {
                Id = p.Id,
                Name = p.Name,
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
                    .ToList(),
                ProductPrice = p.ProductPrices
                .Where(pp => pp.Deleted == false && (pp.DateTo ?? DateOnly.MaxValue) >= currentDate)
                .OrderBy(pp => pp.DateTo ?? DateOnly.MaxValue)
                .Select(pp => new ProductPriceListSpecificationType
                {
                    Id = pp.Id,
                    Value = pp.Value,
                    DateFrom = pp.DateFrom,
                    DateTo = pp.DateTo
                }).FirstOrDefault()
            }).Where(p => p.Id == id && p.Deleted == deleted).
            AsTracking();
    }
}
