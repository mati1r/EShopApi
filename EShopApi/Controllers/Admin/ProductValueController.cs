using Application.DTO.Admin.ProductValue;
using Core.DTO.Admin.ProductValue;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.ProductValue;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductValueController(IProductValueService productValueService) : AdminController
{
    private readonly IProductValueService _productValueService = productValueService;

    [HttpGet]
    [Route("ProductValue")]
    public async Task<List<ProductValueGetListSpecificationType>> GetList([FromQuery] ProductValueGetList data)
    {
        return await _productValueService.GetList(data.ProductTypeId);
    }

    [HttpPost]
    [Route("ProductValue")]
    public async Task Add([FromBody] ProductValueAdd data)
    {
        await _productValueService.Add(data.Name, data.ProductTypeId);
    }

    [HttpPost]
    [Route("ProductValues")]
    public async Task AddMany([FromBody] List<ProductValueAdd> data)
    {
        await _productValueService.AddMany(data);
    }

    [HttpPut]
    [Route("ProductValue")]
    public async Task Update([FromBody] ProductValueUpdate data)
    {
        await _productValueService.Update(data.Id, data.Name, data.ProductTypeId);
    }

    [HttpDelete]
    [Route("ProductValue")]
    public async Task Delete([FromBody] ProductValueDelete data)
    {
        await _productValueService.Delete(data.Id);
    }
}
