using Application.DTO.Admin.ProductPhotos;
using Application.Helpers;
using Core.IServices.Admin;
using Core.SpecificationTypes.Admin.ProductPhotos;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductPhotosController(IProductPhotosService productPhotosService) : AdminController
{
    private readonly IProductPhotosService _productPhotosService = productPhotosService;

    [HttpGet]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductPhotosGetListSpecificationType>> GetList([FromQuery] ProductPhotosGetList data)
    {
        return await _productPhotosService.GetList(data.ProductId, data.Pagination, data.OrderBy, data.Deleted);
    }

    [HttpGet]
    [Route("ProductDescription")]
    public async Task<ProductPhotosGetListSpecificationType> Get([FromQuery] ProductPhotosGet data)
    {
        return await _productPhotosService.Get(
            data.Id
        );
    }

    [HttpPost]
    [Route("ProductDescription")]
    public async Task Add([FromBody] ProductPhotosAdd data)
    {
        var file = await FileHelper.ConvertIFormFileToFileModelAsync(data.Photo);
        await _productPhotosService.Add(
            data.ProductId,
            file
        );
    }

    [HttpPut]
    [Route("Product")]
    public async Task Update([FromBody] ProductPhotosUpdate data)
    {
        var file = await FileHelper.ConvertIFormFileToFileModelAsync(data.Photo);
        await _productPhotosService.Update(
            data.Id,
            file
        );
    }

    [HttpPost]
    [Route("Delete")]
    public async Task Delete([FromBody] ProductPhotosDeleted data)
    {
        await _productPhotosService.Delete(data.Id);
    }

    [HttpPost]
    [Route("Restore")]
    public async Task Restore([FromBody] ProductPhotosDeleted data)
    {
        await _productPhotosService.Restore(data.Id);
    }
}
