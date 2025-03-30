using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.ProductType;
using Core.Specifications.Core;
using Core.SpecificationTypes.Admin.ProductType;

namespace Core.Services.Admin;

public class ProductTypeService(
    IRepository<ProductType> productTypeRepository,
    IRepository<ProductElement> productElementRepostiory,
    IRepository<FilterType> filterTypeRepository
) : IProductTypeService
{
    private readonly IRepository<ProductType> _productTypeRepository = productTypeRepository;
    private readonly IRepository<ProductElement> _productElementRepostiory = productElementRepostiory;
    private readonly IRepository<FilterType> _filterTypeRepository = filterTypeRepository;

    public async Task<List<ProductTypeGetListSpecificationType>> GetList()
    {
        var productTypeListSpec = new ProductTypeGetListSpecification();
        return await _productTypeRepository.ListAsync(productTypeListSpec);
    }

    public async Task Add(string name, int filterTypeId)
    {
        var filterTypee = await _filterTypeRepository.GetByIdAsync(filterTypeId) ?? throw new BadRequestException($"Could not found filter type with id {filterTypeId}"); ;
        var productType = new ProductType(name, filterTypeId);
        await _productTypeRepository.AddAsync(productType);
    }

    public async Task Update(int id, string name, int filterTypeId)
    {
        var productType = await _productTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product type with id {id}");
        productType.Update(name, filterTypeId);
        await _productTypeRepository.UpdateAsync(productType);
    }

    public async Task Delete(int id)
    {
        var productElementsSpec = new UniversalSpecification<ProductElement>(pe => pe.ProductTypeId == id);
        if (await _productElementRepostiory.AnyAsync(productElementsSpec)) throw new BadRequestException($"Cannot delete product type with id: {id} because it is in active usage");

        var productType = await _productTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product type with id {id}");
        await _productTypeRepository.DeleteAsync(productType);
    }
}
