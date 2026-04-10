using Core.DTO.Core;
using Core.SpecificationTypes.Admin.Subcategory;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface ISubcategoryService
{
    public Task<SpecificationListAggregation<SubcategoryGetListSpecificationType>> GetList(int categoryId, AppPaginationList pagination, AppOrderBy orderBy);
    public Task Add(int categoryId, string name);
    public Task Update(int id, int categoryId, string name);
    public Task Delete(int id);
}
