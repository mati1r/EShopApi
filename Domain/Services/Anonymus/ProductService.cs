using Core.DTO.Core;
using Core.IServices.Anonymus;
using Core.Models.EShop;
using Core.Specifications.Anonymus;
using Core.SpecificationTypes.Anonymus.Product;
using Core.SpecificationTypes.Core;

namespace Core.Services.Anonymus;

public class ProductService(IRepository<Product> productRepository) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy)
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy);
        return await _productRepository.AppListAsync(productListSpec, pagination.PerPage, pagination.Page);
    }
}
