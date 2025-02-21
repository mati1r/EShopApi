using Core.IServices.Admin;
using Core.Specifications.Admin;
using Core.SpecificationTypes.Admin.Category;
using EShopApi.Models.EShop;

namespace Core.Services.Admin;

public class CategoryService(
    IRepository<Category> categoryRepository
) : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository = categoryRepository;

    public async Task<List<CategoryGetListSpecificationType>> GetList()
    {
        var categoryGetListSpec = new CategoryGetListSpecification();
        return await _categoryRepository.ListAsync(categoryGetListSpec);
    }

    public async Task Add(string name)
    {
        var category = new Category(name);

        await _categoryRepository.AddAsync(category);
    }
}
