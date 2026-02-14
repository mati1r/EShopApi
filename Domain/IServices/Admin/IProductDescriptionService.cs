using Core.DTO.Core;
using Core.SpecificationTypes.Admin.ProductDescription;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductDescriptionService
{
    public Task<SpecificationListAggregation<ProductDescriptionGetListSpecificationType>> GetList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted);
    public Task<ProductDescriptionGetListSpecificationType> Get(int id);
    public Task Add(int productId, string descriptions);
    public Task Update(int id, int productId, string descriptions);
    public Task Delete(int id);
    public Task Restore(int id);
}
