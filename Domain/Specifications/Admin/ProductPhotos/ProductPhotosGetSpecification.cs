using Ardalis.Specification;
using Core.SpecificationTypes.Admin.ProductPhotos;

namespace Core.Specifications.Admin.ProductPhotos;

public class ProductPhotosGetSpecification : Specification<Models.EShop.ProductPhotos, ProductPhotosGetListSpecificationType>
{ 
    public ProductPhotosGetSpecification(int id)
    {
        var query = Query
            .Select(pd => new ProductPhotosGetListSpecificationType
            {
                Id = pd.Id,
                ProductId = pd.ProductId,
                FileName = pd.FileName,
                Extension = pd.Extenstion,
            }).Where(pd => pd.Deleted == false && pd.Id == id).AsTracking();
    }
}
