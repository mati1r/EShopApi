using Core.DTO.Admin.Request.Product;
using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.IServices.Infrastructure;
using Core.Models.EShop;
using Core.Specifications.Admin.Product;
using Core.Specifications.Anonymus;
using Core.Specifications.Core;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class ProductService(
    IRepository<Product> productRepository,
    IRepository<Subcategory> subcategoryRepository,
    IRepository<ProductPrice> productPriceRepository,
    IStorageService storageService
) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;
    private readonly IRepository<Subcategory> _subcategoryRepository = subcategoryRepository;
    private readonly IRepository<ProductPrice> _productPriceRepository = productPriceRepository;
    private readonly IStorageService _storageService = storageService;
    private readonly string _path = "product-photos";

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(
        int subCategoryId, 
        AppPaginationList pagination, 
        List<AppFilters>? filters, 
        AppOrderBy orderBy,
        bool deleted
    )
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy, deleted);
        var data = await _productRepository.AppListAsync(productListSpec, pagination.PerPage, pagination.Page);

        foreach (var product in data.list)
        {
            if(product.ProductPhotosName == null) continue;
            product.ProductPhotos = [];

            foreach (var photo in product.ProductPhotosName)
            {
                var photoContent = await _storageService.DownloadBytes($"{_path}/{product.Id}/{photo}");
                product.ProductPhotos.Add(photoContent); 
            }
        }

        return data;
    }

    public async Task<ProductGetListSpecificationType> Get(int id, bool deleted = false)
    {
        var productSpec = new ProductGetSpecification(id, deleted);
        return await _productRepository.FirstOrDefaultAsync(productSpec)
            ?? throw new BadRequestException($"Could not found product with id {id}");
    }

    public async Task Add(
        int subcategoryId, 
        string name, 
        List<string> descriptions, 
        List<FileModel> photos, 
        int quantity,
        List<ProductPriceAdd> pricesToAdd
    )
    {
        _productRepository.BeginTransaction();
        try
        {
            _ = await _subcategoryRepository.GetByIdAsync(subcategoryId) ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}");
            var product = new Product(subcategoryId, name, quantity);
            await _productRepository.AddAsync(product);

            List<ProductDescriptions> productDescriptions = [];
            foreach (var description in descriptions)
            {
                productDescriptions.Add(new ProductDescriptions(product.Id, description));
            }

            List<ProductPhotos> productPhotos = [];
            foreach (var photo in photos)
            {
                var generatedName = $"{Guid.NewGuid()}-{photo.FileName}";
                var productPhoto = new ProductPhotos(product.Id, photo.FileName, photo.FileExtension, generatedName);
                productPhotos.Add(productPhoto);
                await _storageService.Upload($"{_path}/{product.Id}/{productPhoto.GeneratedName}", photo.Content);
            }

            product.ProductDescriptions = productDescriptions;
            product.ProductPhotos = productPhotos;  

            foreach (var price in pricesToAdd)
            {
                product.AddPrice(price.Value, price.DateFrom, price.DateTo);
            }

            await _productRepository.UpdateAsync(product);
            _productRepository.CommitTransaction();
        }
        catch (Exception)
        {
            _productRepository.RollbackTransaction();
            throw;
        }
    }
    public async Task Update(
        int id,
        int? subcategoryId, 
        string? name,
        int? quantity,
        List<ProductPriceChange> pricesToChange
    )
    {
        if(subcategoryId != null) _ = await _subcategoryRepository.GetByIdAsync((int)subcategoryId) 
                ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}");

        var product = await _productRepository.GetByIdAsync(id) 
            ?? throw new BadRequestException($"Could not found product with id {id}");

        product.Update(subcategoryId, name, quantity);
        await UpdatePrice(product, pricesToChange);
        await _productRepository.UpdateAsync(product);
    }

    public async Task Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product with id {id}");
        product.Remove();
        await _productRepository.SaveChangesAsync();
    }

    public async Task Restore(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product with id {id}");
        product.Restore();
        await _productRepository.SaveChangesAsync();
    }

    private async Task UpdatePrice(Product product, List<ProductPriceChange> pricesToChange)
    {
        var productIds = pricesToChange.Select(pp => pp.Id);
        var productPricesSpec = new UniversalSpecification<ProductPrice>(pp => pp.Deleted == false && productIds.Contains(pp.Id) && pp.Product.Id == product.Id);
        var productPrices = await _productPriceRepository.ListAsync(productPricesSpec);

        foreach (var priceToChange in pricesToChange)
        {
            var productPrice = productPrices.FirstOrDefault(pp => pp.Id == priceToChange.Id);
            if (productPrice == null)
            {
                continue;
            }

            product.UpdatePrice(productPrice, priceToChange.Value);
        }
    }

    public async Task<SpecificationListAggregation<ProductPriceListSpecificationType>> GetPricesList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted)
    {
        var productSpec = new ProductGetSpecification(productId, deleted);
        if (!await _productRepository.AnyAsync(productSpec)){
            throw new BadRequestException($"Could not found product with id {productId}");
        }

        var productPricesListSpec = new ProductPriceListSpecification(productId, orderBy, deleted);
        return await _productPriceRepository.AppListAsync(productPricesListSpec, pagination.PerPage, pagination.Page);
    }
}
