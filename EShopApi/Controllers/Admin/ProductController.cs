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
            data.Price, 
            files,
            data.Quantity
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
            data.Price, 
            data.Quantity
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
