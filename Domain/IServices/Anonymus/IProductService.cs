using Core.DTO.Core;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Anonymus;

public interface IProductService
{
    public Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy, bool deleted);
}
