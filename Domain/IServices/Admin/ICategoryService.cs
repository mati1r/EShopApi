using Core.DTO.Core;
using Core.SpecificationTypes.Admin.Category;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface ICategoryService
{
    public Task<SpecificationListAggregation<CategoryGetListSpecificationType>> GetList(AppPaginationList pagination, AppOrderBy orderBy);
    public Task Add(string name);
    public Task Update(int id, string name);
    public Task Delete(int id);
}
