using Application.DTO.Admin.ProductElement;
using Core.DTO.Admin.ProductElement;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.ProductElement;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductElementController(IProductElementService productElementService) : AdminController
{
    private readonly IProductElementService _productElementService = productElementService;

    [HttpGet]
    [Route("ProductElement")]
    public async Task<List<ProductElementGetListSpecificationType>> GetList([FromQuery] ProductElementGetList data)
    {
        return await _productElementService.GetList(data.ProductId);
    }

    [HttpPost]
    [Route("ProductElement")]
    public async Task Add([FromBody] ProductElementAdd data)
    {
        await _productElementService.Add(data.ProductValueId, data.ProductValueId, data.ProductId);
    }

    [HttpPost]
    [Route("ProductElements")]
    public async Task AddMany([FromBody] List<ProductElementAdd> data)
    {
        await _productElementService.AddMany(data);
    }


    [HttpPut]
    [Route("ProductElement")]
    public async Task Update([FromBody] ProductElementUpdate data)
    {
        await _productElementService.Update(data.Id, data.ProductTypeId, data.ProductTypeId, data.ProductId);
    }

    [HttpDelete]
    [Route("ProductElement")]
    public async Task Delete([FromBody] ProductElementDelete data)
    {
        await _productElementService.Delete(data.Id);
    }
}
