using Core.DTO.Admin.ProductElement;
using Core.SpecificationTypes.Admin.ProductElement;

namespace Core.IServices.Admin;

public interface IProductElementService
{
    public Task<List<ProductElementGetListSpecificationType>> GetList(int productId);
    public Task Add(int productTypeId, int productValueId, int productId);
    public Task AddMany(List<ProductElementAdd> data);
    public Task Update(int id, int productTypeId, int productValueId, int productId);
    public Task Delete(int id);
}
