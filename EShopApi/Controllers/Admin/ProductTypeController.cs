using Application.DTO.Admin.Category;
using Application.DTO.Admin.ProductType;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.Category;
using Core.SpecificationTypes.Admin.ProductType;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductTypeController(IProductTypeService productTypeService) : AdminController
{
    private readonly IProductTypeService _productTypeService = productTypeService;

    [HttpGet]
    [Route("Category")]
    public async Task<List<ProductTypeGetListSpecificationType>> GetList()
    {
        return await _productTypeService.GetList();
    }

    [HttpPost]
    [Route("Category")]
    public async Task Add([FromBody] ProductTypeAdd data)
    {
        await _productTypeService.Add(data.Name, data.FilterTypeId);
    }

    [HttpPut]
    [Route("Category")]
    public async Task Update([FromBody] ProductTypeUpdate data)
    {
        await _productTypeService.Update(data.Id, data.Name, data.FilterTypeId);
    }

    [HttpDelete]
    [Route("Category")]
    public async Task Delete([FromBody] ProductTypeDelete data)
    {
        await _productTypeService.Delete(data.Id);
    }
}
