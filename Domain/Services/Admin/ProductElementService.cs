using Core.DTO.Admin.ProductElement;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.ProductElement;
using Core.Specifications.Core;
using Core.SpecificationTypes.Admin.ProductElement;

namespace Core.Services.Admin;

public class ProductElementService(
    IRepository<ProductElement> productElementRepository,
    IRepository<ProductType> productTypeRepository,
    IRepository<ProductValue> productValueRepository,
    IRepository<Product> productRepository
) : IProductElementService
{
    private readonly IRepository<ProductElement> _productElementRepository = productElementRepository;
    private readonly IRepository<ProductType> _productTypeRepository = productTypeRepository;
    private readonly IRepository<ProductValue> _productValueRepository = productValueRepository;
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<List<ProductElementGetListSpecificationType>> GetList(int productId)
    {
        var productElementListSpec = new ProductElementGetListSpecification(productId);
        return await _productElementRepository.ListAsync(productElementListSpec);
    }

    public async Task Add(int productTypeId, int productValueId, int productId)
    {
        var productType = await _productTypeRepository.GetByIdAsync(productTypeId) ?? throw new BadRequestException($"Could not found product type with id {productTypeId}");
        var productValue = await _productValueRepository.GetByIdAsync(productValueId) ?? throw new BadRequestException($"Could not found product value with id {productValueId}");
        var product = await _productRepository.GetByIdAsync(productId) ?? throw new BadRequestException($"Could not found product with id {productId}");

        var productElement = new ProductElement(productTypeId, productValueId, productId);
        await _productElementRepository.AddAsync(productElement);
    }

    public async Task AddMany(List<ProductElementAdd> data)
    {
        var productTypeIds = data.Select(x => x.ProductId).ToList();
        var productValueIds = data.Select(x => x.ProductValueId).ToList();
        var productIds = data.Select(x=> x.ProductId).ToList();

        var productTypeSpec = new UniversalSpecification<ProductType>(pt => productTypeIds.Contains(pt.Id));
        var productTypesCount = await _productTypeRepository.CountAsync(productTypeSpec);

        var productValueSpec = new UniversalSpecification<ProductValue>(pv => productValueIds.Contains(pv.Id));
        var productValuesCount = await _productValueRepository.CountAsync(productValueSpec);

        var productSpec = new UniversalSpecification<Product>(p => productIds.Contains(p.Id));
        var productsCount = await _productRepository.CountAsync(productSpec);

        if (productTypesCount != productTypeIds.Count) throw new BadRequestException($"Some of product types does not exist {productTypeIds}");
        if (productValuesCount != productValueIds.Count) throw new BadRequestException($"Some of product values does not exist {productValueIds}");
        if (productsCount != productIds.Count) throw new BadRequestException($"Some of products does not exist {productIds}");

        List<ProductElement> productElements = [];

        foreach (var productElementData in data)
        {
            var newProductElement = new ProductElement(productElementData.ProductTypeId, productElementData.ProductValueId, productElementData.ProductId);
            productElements.Add(newProductElement);
        }

        await _productElementRepository.AddRangeAsync(productElements);
    }

    public async Task Update(int id, int productTypeId, int productValueId, int productId)
    {
        var productElement = await _productElementRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product element with id {id}");
        productElement.Update(productTypeId, productValueId, productId);
        await _productElementRepository.UpdateAsync(productElement);
    }

    public async Task Delete(int id)
    {
        var productElement = await _productElementRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found product element with id {id}");
        await _productElementRepository.DeleteAsync(productElement);
    }
}
