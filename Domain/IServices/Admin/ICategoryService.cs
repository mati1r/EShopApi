using Core.SpecificationTypes.Admin.Category;
using EShopApi.Models.EShop;

namespace Core.IServices.Admin;

public interface ICategoryService
{
    public Task<List<CategoryGetListSpecificationType>> GetList();
    public Task Add(string name);
}
