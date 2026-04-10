using Core.DTO.Admin.Request.ProductValue;
using Core.DTO.Core;
using Core.SpecificationTypes.Admin.ProductValue;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductValueService
{
    public Task<SpecificationListAggregation<ProductValueGetListSpecificationType>> GetList(int productTypeId, AppPaginationList pagination, AppOrderBy orderBy);
    public Task Add(string name, int? value, int productTypeId);
    public Task AddMany(List<ProductValueAdd> data);
    public Task Update(int id, string name, int? value, int productTypeId);
    public Task Delete(int id);
}
