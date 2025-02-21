using Core.Exceptions;
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

    public async Task Update(int id, string name)
    {
        var category = await _categoryRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found category with id {id}");
        category.Update(name);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found category with id {id}");
        await _categoryRepository.DeleteAsync(category);
    }
}
