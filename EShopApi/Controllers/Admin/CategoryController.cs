using Application.DTO.Admin.Category;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.Category;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class CategoryController(ICategoryService categoryService) : AdminController
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    [Route("Category")]
    public async Task<List<CategoryGetListSpecificationType>> GetList()
    {
        return await _categoryService.GetList();
    }

    [HttpPost]
    [Route("Category")]
    public async Task Add([FromBody] CategoryAdd data)
    {
        await _categoryService.Add(data.Name);
    }

    [HttpPut]
    [Route("Category")]
    public async Task Update([FromBody] CategoryUpdate data)
    {
        await _categoryService.Update(data.Id, data.Name);
    }

    [HttpDelete]
    [Route("Category")]
    public async Task Delete([FromBody] CategoryDelete data)
    {
        await _categoryService.Delete(data.Id);
    }
}
