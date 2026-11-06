using Core.DTO.Admin.Request.Product;
using Core.DTO.Core;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductService
{
    public Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy, bool deleted);
    public Task<ProductGetListSpecificationType> Get(int id, bool deleted = false);
    public Task Add(int subcategoryId, string name, List<string> descriptions, List<FileModel> photos, int quantity, List<ProductPriceAdd> pricesToAdd);
    public Task Update(int id, int? subcategoryId, string? name, int? quantity, List<ProductPriceChange> pricesToChange);
    public Task Delete(int id);
    public Task Restore(int id);
    public Task<SpecificationListAggregation<ProductPriceListSpecificationType>> GetPricesList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted);
}
