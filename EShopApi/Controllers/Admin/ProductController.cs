using Application.DTO.Admin;
using Application.DTO.Admin.Product;
using Application.Helpers;
using Core.DTO.Core;
using Core.IServices.Admin;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductController(IProductService productService) : AdminController
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList([FromQuery] ProductGetList data)
    {
        return await _productService.GetList(data.SubCategoryId, data.Pagination, data.Filters, data.OrderBy, data.Deleted);
    }

    [HttpGet]
    [Route("GetPrices")]
    public async Task<SpecificationListAggregation<ProductPriceListSpecificationType>> GetList([FromQuery] ProductPricesGetList data)
    {
        return await _productService.GetPricesList(data.ProductId, data.Pagination, data.OrderBy, data.Deleted);
    }

    [HttpGet]
    [Route("Product")]
    public async Task<ProductGetListSpecificationType> GetList([FromQuery] ProductGet data)
    {
        return await _productService.Get(data.Id, data.Deleted);
    }

    [HttpPost]
    [Route("Product")]
    public async Task Add([FromForm] ProductAdd data)
    {
        List<FileModel> files = [];

        foreach (var photo in data.Photos)
        {
            var file = await FileHelper.ConvertIFormFileToFileModelAsync(photo);
            files.Add(file);
        }

        await _productService.Add(
            data.SubcategoryId, 
            data.Name,
            data.Descriptions,
            files,
            data.Quantity,
            data.PricesToAdd
        );
    }

    [HttpPut]
    [Route("Product")]
    public async Task Update([FromBody] ProductUpdate data)
    {
        await _productService.Update(
            data.Id, 
            data.SubcategoryId, 
            data.Name,
            data.Quantity,
            data.PricesToChange
        );
    }

    [HttpDelete]
    [Route("Product")]
    public async Task Delete([FromBody] ProductDelete data)
    {
        await _productService.Delete(data.Id);
    }

    [HttpPost]
    [Route("Restore")]
    public async Task Restore([FromBody] ProductDelete data)
    {
        await _productService.Restore(data.Id);
    }
}
