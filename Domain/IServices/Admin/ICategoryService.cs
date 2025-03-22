using Core.SpecificationTypes.Admin.Category;

namespace Core.IServices.Admin;

public interface ICategoryService
{
    public Task<List<CategoryGetListSpecificationType>> GetList();
    public Task Add(string name);
    public Task Update(int id, string name);
    public Task Delete(int id);
}
