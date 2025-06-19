using Core.DTO.Core;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductService
{
    public Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy);
    public Task Add(int subcategoryId, string name, string? description1, string? description2, string? description3, double price, string? descriptionPhoto1, string? descriptionPhoto2, int quantity);
    public Task Update(int id, int? subcategoryId, string? name, string? description1, string? description2, string? description3, double? price, string? descriptionPhoto1, string? descriptionPhoto2, int? quantity);
    public Task Delete(int id);
    public Task Restore(int id);
}
