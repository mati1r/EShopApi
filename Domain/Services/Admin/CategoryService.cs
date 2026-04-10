using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.Category;
using Core.SpecificationTypes.Admin.Category;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class CategoryService(
    IRepository<Category> categoryRepository
) : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository = categoryRepository;

    public async Task<SpecificationListAggregation<CategoryGetListSpecificationType>> GetList(AppPaginationList pagination, AppOrderBy orderBy)
    {
        var categoryGetListSpec = new CategoryGetListSpecification(orderBy);
        return await _categoryRepository.AppListAsync(categoryGetListSpec, pagination.PerPage, pagination.Page);
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
