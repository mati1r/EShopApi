using Application.DTO.Admin.ProductType;
using Application.DTO.Common;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.ProductType;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductTypeController(IProductTypeService productTypeService) : AdminController
{
    private readonly IProductTypeService _productTypeService = productTypeService;

    [HttpGet]
    [Route("Category")]
    public async Task<SpecificationListAggregation<ProductTypeGetListSpecificationType>> GetList([FromQuery] AppBasicContentControl data)
    {
        return await _productTypeService.GetList(data.Pagination, data.OrderBy);
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
