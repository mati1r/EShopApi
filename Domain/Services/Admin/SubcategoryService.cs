using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.Subcategory;
using Core.SpecificationTypes.Admin.Subcategory;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class SubcategoryService(IRepository<Subcategory> subcategoryRepository) : ISubcategoryService
{
    private readonly IRepository<Subcategory> _subcategoryRepository = subcategoryRepository;

    public async Task<SpecificationListAggregation<SubcategoryGetListSpecificationType>> GetList(int categoryId, AppPaginationList pagination, AppOrderBy orderBy)
    {
        var getListSpec = new SubcategoryGetListSpecification(categoryId, orderBy);
        return await _subcategoryRepository.AppListAsync(getListSpec, pagination.PerPage, pagination.Page);
    }

    public async Task Add(int categoryId, string name)
    {
        _ = await _subcategoryRepository.GetByIdAsync(categoryId) ?? throw new BadRequestException($"Could not found category with id {categoryId}");

        var subcategory = new Subcategory(categoryId, name);
        await _subcategoryRepository.AddAsync(subcategory);
    }

    public async Task Update(int id, int categoryId, string name)
    {
        var subcategory = await _subcategoryRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found subcategory with id {id}");
        _ = await _subcategoryRepository.GetByIdAsync(categoryId) ?? throw new BadRequestException($"Could not found category with id {categoryId}");

        subcategory.Update(categoryId, name);
        await _subcategoryRepository.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var subcategory = await _subcategoryRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found subcategory type with id {id}");
        await _subcategoryRepository.DeleteAsync(subcategory);
    }
}
