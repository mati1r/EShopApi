using Core.DTO.Core;
using Core.SpecificationTypes.Admin.ProductType;
using Core.SpecificationTypes.Core;
namespace Core.IServices.Admin;

public interface IProductTypeService
{
    public Task<SpecificationListAggregation<ProductTypeGetListSpecificationType>> GetList(AppPaginationList pagination, AppOrderBy orderBy);
    public Task Add(string name, int filterTypeId);
    public Task Update(int id, string name, int filterTypeId);
    public Task Delete(int id);
}
