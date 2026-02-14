using System.Xml.Linq;
using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.IServices.Infrastructure;
using Core.Models.EShop;
using Core.Specifications.Anonymus;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class ProductService(
    IRepository<Product> productRepository,
    IRepository<Subcategory> subcategoryRepository,
    IStorageService storageService
) : IProductService
{
    private readonly IRepository<Product> _productRepository = productRepository;
    private readonly IRepository<Subcategory> _subcategoryRepository = subcategoryRepository;
    private readonly IStorageService _storageService = storageService;
    private readonly string _path = "product-photos/";

    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList(
        int subCategoryId, 
        AppPaginationList pagination, 
        List<AppFilters>? filters, 
        AppOrderBy orderBy
    )
    {
        var productListSpec = new ProductGetListSpecification(subCategoryId, filters, orderBy);
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

    public async Task Add(
        int subcategoryId, 
        string name, 
        List<string> descriptions, 
        double price, 
        List<FileModel> photos, 
        int quantity
    )
    {
        _productRepository.BeginTransaction();
        try
        {
            _ = await _subcategoryRepository.GetByIdAsync(subcategoryId) ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}"); ;
            var product = new Product(subcategoryId, name, price, quantity);
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
                var productPhoto = new ProductPhotos(product.Id, photo.FileName, generatedName);
                productPhotos.Add(productPhoto);
                await _storageService.Upload($"{_path}/{product.Id}/{productPhoto.GeneratedName}", photo.Content);
            }

            product.ProductDescriptions = productDescriptions;
            product.ProductPhotos = productPhotos;  

            await _productRepository.UpdateAsync(product);
            _productRepository.CommitTransaction();
        }
        catch (Exception)
        {
            _productRepository.RollbackTransaction();
            throw;
        }

        //Photos should be files that are going to be uploaded to S3 storage, but for now they are not there
    }
    public async Task Update(
        int id,
        int? subcategoryId, 
        string? name,
        double? price, 
        int? quantity
    )
    {
        if(subcategoryId != null) _ = await _subcategoryRepository.GetByIdAsync((int)subcategoryId) 
                ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}");

        var product = await _productRepository.GetByIdAsync(id) 
            ?? throw new BadRequestException($"Could not found product with id {id}");

        product.Update(subcategoryId, name, price, quantity);
        await _productRepository.UpdateAsync(product);
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
