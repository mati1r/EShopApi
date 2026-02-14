using Application.DTO.Admin.ProductDescription;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.ProductDescription;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductDescriptionController(IProductDescriptionService productDescriptionService) : AdminController
{
    private readonly IProductDescriptionService _productDescriptionService = productDescriptionService;

    [HttpGet]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductDescriptionGetListSpecificationType>> GetList([FromQuery] ProductDescriptionGetList data)
    {
        return await _productDescriptionService.GetList(data.ProductId, data.Pagination, data.OrderBy, data.Deleted);
    }

    [HttpGet]
    [Route("ProductDescription")]
    public async Task<ProductDescriptionGetListSpecificationType> Get([FromQuery] ProductDescriptionGet data)
    {
        return await _productDescriptionService.Get(
            data.Id
        );
    }

    [HttpPost]
    [Route("ProductDescription")]
    public async Task Add([FromBody] ProductDescriptionAdd data)
    {
        await _productDescriptionService.Add(
            data.ProductId,
            data.Descriptions
        );
    }

    [HttpPut]
    [Route("Product")]
    public async Task Update([FromBody] ProductDescriptionUpdate data)
    {
        await _productDescriptionService.Update(
            data.Id,
            data.ProductId,
            data.Descriptions
        );
    }

    [HttpPost]
    [Route("Delete")]
    public async Task Delete([FromBody] ProductDescriptionDelete data)
    {
        await _productDescriptionService.Delete(data.Id);
    }

    [HttpPost]
    [Route("Restore")]
    public async Task Restore([FromBody] ProductDescriptionDelete data)
    {
        await _productDescriptionService.Restore(data.Id);
    }
}
