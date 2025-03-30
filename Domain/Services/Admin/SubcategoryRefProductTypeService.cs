using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;

namespace Core.Services.Admin;

public class SubcategoryRefProductTypeService(
    IRepository<SubcategoryRefProductType> subcategoryRefProductRepository,
    IRepository<Subcategory> subcategoryRepository,
    IRepository<ProductType> productTypeRepostiory
) : ISubcategoryRefProductTypeService
{
    private readonly IRepository<SubcategoryRefProductType> _subcategoryRefProductRepository = subcategoryRefProductRepository;
    private readonly IRepository<Subcategory> _subcategoryRepository = subcategoryRepository;
    private readonly IRepository<ProductType> _productTypeRepostiory = productTypeRepostiory;

    public async Task Add(int subcategoryId, int productTypeId)
    {
        var subcategory = await _subcategoryRepository.GetByIdAsync(productTypeId) ?? throw new BadRequestException($"Could not found subcategory with id {subcategoryId}");
        var productType = await _productTypeRepostiory.GetByIdAsync(productTypeId) ?? throw new BadRequestException($"Could not found product type with id {productTypeId}");

        var subcategoryRefProductType = new SubcategoryRefProductType(subcategoryId, productTypeId);
        await _subcategoryRefProductRepository.AddAsync(subcategoryRefProductType);
    }

    public async Task Delete(int subcategoryId, int productTypeId)
    {
        var subcategoryRefProductType = await _subcategoryRefProductRepository.GetByCompositeKeyAsync(subcategoryId, productTypeId) 
            ?? throw new BadRequestException($"Could not found subcategoryRefProductType with subcategory id: {subcategoryId} and product type id: {productTypeId}");
        await _subcategoryRefProductRepository.DeleteAsync(subcategoryRefProductType);
    }
}
