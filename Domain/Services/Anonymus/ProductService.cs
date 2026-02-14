using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Anonymus;
using Core.Models.EShop;
using Core.Specifications.Anonymus;
using Core.SpecificationTypes.Core;

namespace Core.Services.Anonymus;

public class ProductService(IRepository<Product> productRepository) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(
        int subCategoryId, 
        AppPaginationList pagination, 
        List<AppFilters>? filters, 
        AppOrderBy orderBy,
        bool deleted
    )
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy, deleted);
        return await _productRepository.AppListAsync(productListSpec, pagination.PerPage, pagination.Page);
    }

    public async Task<ProductGetListSpecificationType> Get(int id)
    {
        var productSpec = new ProductGetSpecification(id, false);
        return await _productRepository.FirstOrDefaultAsync(productSpec)
            ?? throw new BadRequestException($"Could not found product with id {id}");
    }
}
