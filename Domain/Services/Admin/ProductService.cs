using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.Product;

namespace Core.Services.Admin;

public class ProductService : IProductService
{
    public Task<List<ProductGetListSpecificationType>> GetList()
    {
        throw new NotImplementedException();
    }
    public Task Add(
        int subcategoryId, 
        string? description1, 
        string? description2, 
        string? description3, 
        double price,
        string? descriptionPhoto1,
        string? descriptionPhoto2,
        int quantity
    )
    {
        throw new NotImplementedException();
    }
    public Task Update(
        int id,
        int subcategoryId, 
        string? description1, 
        string? description2, 
        string? description3, 
        double price, 
        string? descriptionPhoto1, 
        string? descriptionPhoto2, 
        int quantity, 
        bool hidden
    )
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
