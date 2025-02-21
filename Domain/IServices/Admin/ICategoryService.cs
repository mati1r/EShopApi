using EShopApi.Models.EShop;

namespace Core.IServices.Admin;

public interface ICategoryService
{
    public Task<List<Category>> GetList();
}
