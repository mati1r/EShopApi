using Core.DTO.Admin.ProductValue;
using Core.SpecificationTypes.Admin.ProductValue;

namespace Core.IServices.Admin;

public interface IProductValueService
{
    public Task<List<ProductValueGetListSpecificationType>> GetList(int productTypeId);
    public Task Add(string name, int productTypeId);
    public Task AddMany(List<ProductValueAdd> data);
    public Task Update(int id, string name, int productTypeId);
    public Task Delete(int id);
}
