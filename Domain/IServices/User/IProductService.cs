using Core.DTO.Core;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Product;

namespace Core.IServices.User;

public interface IProductService
{
    public Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters> filters, AppOrderBy orderBy);
}
