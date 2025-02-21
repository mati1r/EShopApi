using Core.IServices.Admin;
using EShopApi.Models.EShop;

namespace Core.Services.Admin;

public class CategoryService(
    IRepository<Category> categoryRepository
) : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository = categoryRepository;

    public async Task<List<Category>> GetList()
    {
        return await _categoryRepository.ListAsync();
    }
}
