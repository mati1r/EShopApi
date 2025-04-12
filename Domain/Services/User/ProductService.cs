using Core.DTO.Core;
using Core.IServices.User;
using Core.Models.EShop;
using Core.Specifications.User;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Product;

namespace Core.Services.User;

public class ProductService(IRepository<Product> productRepository) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters> filters, AppOrderBy orderBy)
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy);
        return await _productRepository.AppListAsync(productListSpec, pagination.PerPage, pagination.Page);
    }
}
