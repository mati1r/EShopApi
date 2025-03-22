using Core.SpecificationTypes.Admin.ProductType;
namespace Core.IServices.Admin;

public interface IProductTypeService
{
    public Task<List<ProductTypeGetListSpecificationType>> GetList();
    public Task Add(string name, int filterTypeId);
    public Task Update(int id, string name, int filterTypeId);
    public Task Delete(int id);
}
