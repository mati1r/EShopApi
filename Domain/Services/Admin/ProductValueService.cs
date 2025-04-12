using Core.DTO.Admin.ProductValue;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.ProductValue;
using Core.Specifications.Core;
using Core.SpecificationTypes.Admin.ProductValue;

namespace Core.Services.Admin;

public class ProductValueService(
    IRepository<ProductValue> productValueRepository,
    IRepository<ProductType> productTypeRepository,
    IRepository<ProductElement> productElementRepository
) : IProductValueService
{
    private readonly IRepository<ProductValue> _productValueRepository = productValueRepository;
    private readonly IRepository<ProductType> _productTypeRepository = productTypeRepository;
    private readonly IRepository<ProductElement> _productElementRepository = productElementRepository;

    public async Task<List<ProductValueGetListSpecificationType>> GetList(int productTypeId)
    {
        var productValueListSpec = new ProductValueGetListSpecification(productTypeId);
        return await _productValueRepository.ListAsync(productValueListSpec);
    }

    public async Task Add(string name, int? value, int productTypeId)
    {
        var productType = await _productTypeRepository.GetByIdAsync(productTypeId) ?? throw new BadRequestException($"Could not found product type with id {productTypeId}");

        var productValue = new ProductValue(productTypeId, name, value);
        await _productValueRepository.AddAsync(productValue);
    }

    public async Task AddMany(List<ProductValueAdd> data)
    {
        var productTypeIds = data.Select(x => x.ProductTypeId).ToList();
        var productTypesSpec = new UniversalSpecification<ProductType>(pt => productTypeIds.Contains(pt.Id));
        var productTypeCount = await _productTypeRepository.CountAsync(productTypesSpec);

        if (productTypeCount != productTypeIds.Count) throw new BadRequestException($"Some of product types does not exist {productTypeIds}");

        List<ProductValue> productValues = [];

        foreach (var productValueData in data)
        {
            var productValue = new ProductValue(productValueData.ProductTypeId, productValueData.Name, productValueData.Value);
            productValues.Add(productValue);
        }

        await _productValueRepository.AddRangeAsync(productValues);
    }

    public async Task Update(int id, string name, int? value, int productTypeId)
    {
        var productValue = await _productValueRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product value with id {id}");
        productValue.Update(name, value, productTypeId);
        await _productValueRepository.UpdateAsync(productValue);
    }

    public async Task Delete(int id)
    {
        var productElementsSpec = new UniversalSpecification<ProductElement>(pe => pe.ProductValueId == id);
        if(await _productElementRepository.AnyAsync(productElementsSpec)) throw new BadRequestException($"Cannot delete product value with id: {id} because it is in active usage");

        var productValue = await _productValueRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product value with id {id}");
        await _productValueRepository.DeleteAsync(productValue);
    }
}
