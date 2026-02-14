using Core.DTO.Core;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductService
{
    public Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy);
    public Task Add(int subcategoryId, string name, List<string> descriptions, double price, List<FileModel> photos, int quantity);
    public Task Update(int id, int? subcategoryId, string? name, double? price, int? quantity);
    public Task Delete(int id);
    public Task Restore(int id);
}
