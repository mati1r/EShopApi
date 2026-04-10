using Application.DTO.Admin.Category;
using Application.DTO.Admin.Subcategory;
using Application.DTO.Common;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.Category;
using Core.SpecificationTypes.Admin.Subcategory;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class SubcategoryController(ISubcategoryService subcategoryService) : AdminController
{
    private readonly ISubcategoryService _subcategoryService = subcategoryService;

    [HttpGet]
    [Route("Category")]
    public async Task<SpecificationListAggregation<SubcategoryGetListSpecificationType>> GetList([FromQuery] SubcategoryGetList data)
    {
        return await _subcategoryService.GetList(data.CategoryId, data.Pagination, data.OrderBy);
    }

    [HttpPost]
    [Route("Category")]
    public async Task Add([FromBody] SubcategoryAdd data)
    {
        await _subcategoryService.Add(data.CategoryId, data.Name);
    }

    [HttpPut]
    [Route("Category")]
    public async Task Update([FromBody] SubcategoryUpdate data)
    {
        await _subcategoryService.Update(data.Id, data.CategoryId, data.Name);
    }

    [HttpDelete]
    [Route("Category")]
    public async Task Delete([FromBody] SubcategoryDelete data)
    {
        await _subcategoryService.Delete(data.Id);
    }
}
