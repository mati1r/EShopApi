using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.ProductDescription;
using Core.Specifications.Core;
using Core.SpecificationTypes.Admin.ProductDescription;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class ProductDescriptionService(IRepository<ProductDescriptions> productDescriptionService) : IProductDescriptionService
{
    private readonly IRepository<ProductDescriptions> _productDescriptionService = productDescriptionService;

    public async Task<SpecificationListAggregation<ProductDescriptionGetListSpecificationType>> GetList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted)
    {
        var listSpec = new ProductDescriptionGetListSpecification(productId, orderBy, deleted);
        return await _productDescriptionService.AppListAsync(listSpec, pagination.PerPage, pagination.Page);
    }
    public async Task<ProductDescriptionGetListSpecificationType> Get(int id)
    {
        var productDescriptionSpec = new ProductDescriptionGetSpecification(id);
        return await _productDescriptionService.FirstOrDefaultAsync(productDescriptionSpec) ?? throw new BadRequestException($"Could not found product description with id {id}");
    }

    public async Task Add(int productId, string descriptions)
    {
        var productDescription = new ProductDescriptions(productId, descriptions);
        await _productDescriptionService.AddAsync(productDescription);
    }

    public async Task Update(int id, int productId, string descriptions)
    {
        var productDescriptionSpec = new UniversalSpecification<ProductDescriptions>(pd => pd.Id == id);
        var productDescription = _productDescriptionService.FirstOrDefaultAsync(productDescriptionSpec).Result 
            ?? throw new BadRequestException($"Could not found product description with id {id}");

        productDescription.Update(descriptions);
        await _productDescriptionService.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var productDescriptionSpec = new UniversalSpecification<ProductDescriptions>(pd => pd.Id == id);
        var productDescription = _productDescriptionService.FirstOrDefaultAsync(productDescriptionSpec).Result
            ?? throw new BadRequestException($"Could not found product description with id {id}");

        productDescription.Remove();
        await _productDescriptionService.SaveChangesAsync();
    }

    public async Task Restore(int id)
    {
        var productDescriptionSpec = new UniversalSpecification<ProductDescriptions>(pd => pd.Id == id);
        var productDescription = _productDescriptionService.FirstOrDefaultAsync(productDescriptionSpec).Result
            ?? throw new BadRequestException($"Could not found product description with id {id}");

        productDescription.Restore();
        await _productDescriptionService.SaveChangesAsync();
    }
}
