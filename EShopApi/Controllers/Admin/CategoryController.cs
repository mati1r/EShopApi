using Core.IServices.Admin;
using EShopApi.Models.EShop;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin
{
    public class CategoryController(ICategoryService categoryService) : AdminController
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        [Route("Category")]
        public async Task<List<Category>> Category()
        {
            return await _categoryService.GetList();
        }
    }
}
