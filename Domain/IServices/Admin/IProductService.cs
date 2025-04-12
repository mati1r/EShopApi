using Core.SpecificationTypes.Admin.Product;

namespace Core.IServices.Admin;

public interface IProductService
{
    public Task<List<ProductGetListSpecificationType>> GetList();
    public Task Add(int subcategoryId, string? description1, string? description2, string? description3, double price, string? descriptionPhoto1, string? descriptionPhoto2, int quantity);
    public Task Update(int id, int subcategoryId, string? description1, string? description2, string? description3, double price, string? descriptionPhoto1, string? descriptionPhoto2, int quantity, bool hidden);
    public Task Delete(int id);
}
