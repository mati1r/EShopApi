using Core.SpecificationTypes.Common;

namespace Core.IServices.Admin;

public interface IFilterTypeService
{
    public Task<List<SelectListSpecificationType>> GetList();
    public Task Add(string name);
    public Task Update(int id, string name);
    public Task Delete(int id);
}
