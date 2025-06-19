using System.Xml.Linq;
using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Anonymus;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class ProductService(
    IRepository<Product> productRepository,
    IRepository<Subcategory> subcategoryRepository
) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;
    private readonly IRepository<Subcategory> _subcategoryRepository = subcategoryRepository;

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(int subCategoryId, AppPaginationList pagination, List<AppFilters>? filters, AppOrderBy orderBy)
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy);
        return await _productRepository.AppListAsync(productListSpec, pagination.PerPage, pagination.Page);
    }

    public async Task Add(
        int subcategoryId, 
        string name,
        string? description1, 
        string? description2, 
        string? description3, 
        double price,
        string? descriptionPhoto1,
        string? descriptionPhoto2,
        int quantity
    )
    {
        _ = await _subcategoryRepository.GetByIdAsync(subcategoryId) ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}"); ;
        var product = new Product(subcategoryId, name, price, quantity, description1, description2, description3, descriptionPhoto1, descriptionPhoto2);
        await _productRepository.AddAsync(product);

        //Photos should be files that are going to be uploaded to S3 storage, but for now they are not there
    }
    public async Task Update(
        int id,
        int? subcategoryId, 
        string? name,
        string? description1, 
        string? description2, 
        string? description3, 
        double? price, 
        string? descriptionPhoto1, 
        string? descriptionPhoto2, 
        int? quantity
    )
    {
        if(subcategoryId != null) _ = await _subcategoryRepository.GetByIdAsync((int)subcategoryId) ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}");
        var product = await _productRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product with id {id}");
        product.Update(subcategoryId, name, price, quantity, description1, description2, description3, descriptionPhoto1, descriptionPhoto2);
        await _productRepository.UpdateAsync(product);

        //Photos should be files that are going to be uploaded to S3 storage, but for now they are not there
    }

    public async Task Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product with id {id}");
        product.Delete();
        await _productRepository.SaveChangesAsync();
    }

    public async Task Restore(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product with id {id}");
        product.Restore();
        await _productRepository.SaveChangesAsync();
    }
}
