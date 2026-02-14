using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.IServices.Infrastructure;
using Core.Models.EShop;
using Core.Specifications.Admin.ProductPhotos;
using Core.Specifications.Anonymus;
using Core.Specifications.Core;
using Core.SpecificationTypes.Admin.ProductPhotos;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class ProductPhotosService(IRepository<ProductPhotos> productPhotosRepository, IStorageService storageService) : IProductPhotosService
{
    private readonly IRepository<ProductPhotos> _productPhotosRepository = productPhotosRepository;
    private readonly IStorageService _storageService = storageService;
    private readonly string _path = "product-photos";

    public async Task<SpecificationListAggregation<ProductPhotosGetListSpecificationType>> GetList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted)
    {
        var dataSpec = new ProductPhotosGetListSpecification(productId, orderBy, deleted);
        var data = await _productPhotosRepository.AppListAsync(dataSpec, pagination.PerPage, pagination.Page);

        foreach (var photo in data.list)
        {
            var photoContent = await _storageService.DownloadBytes($"{_path}/{photo.ProductId}/{photo}");
            photo.Content = photoContent;

        }

        return data;
    }
    public async Task<ProductPhotosGetListSpecificationType> Get(int id)
    {
        var photoSpec = new ProductPhotosGetSpecification(id);
        var photo = await _productPhotosRepository.FirstOrDefaultAsync(photoSpec) 
            ?? throw new BadRequestException($"Could not found product photo with id {id}");

        var photoContent = await _storageService.DownloadBytes($"{_path}/{photo.ProductId}/{photo}");
        photo.Content = photoContent;

        return photo;
    }

    public async Task Add(int productId, FileModel file)
    {
        var generatedName = $"{Guid.NewGuid()}-{file.FileName}";
        var photo = new ProductPhotos(productId, file.FileName, file.FileExtension, generatedName);

        await _productPhotosRepository.AddAsync(photo);
        await _storageService.Upload($"{_path}/{productId}/{generatedName}", file.Content);
    }

    public async Task Update(int id, FileModel file)
    {
        var generatedName = $"{Guid.NewGuid()}-{file.FileName}";
        var photoSpec = new UniversalSpecification<ProductPhotos>(pp => pp.Id == id);
        var photo = _productPhotosRepository.FirstOrDefaultAsync(photoSpec).Result 
            ?? throw new BadRequestException($"Could not found product photo with id {id}");

        await _storageService.Upload($"{_path}/{photo.ProductId}/{generatedName}", file.Content);
    }

    public async Task Delete(int id)
    {
        var photoSpec = new UniversalSpecification<ProductPhotos>(pp => pp.Id == id);
        var photo = _productPhotosRepository.FirstOrDefaultAsync(photoSpec).Result 
            ?? throw new BadRequestException($"Could not found product photo with id {id}");

        photo.Remove();

        await _productPhotosRepository.SaveChangesAsync();
    }

    public async Task Restore(int id)
    {
        var photoSpec = new UniversalSpecification<ProductPhotos>(pp => pp.Id == id);
        var photo = _productPhotosRepository.FirstOrDefaultAsync(photoSpec).Result
            ?? throw new BadRequestException($"Could not found product photo with id {id}");

        photo.Restore();

        await _productPhotosRepository.SaveChangesAsync();
    }
}
