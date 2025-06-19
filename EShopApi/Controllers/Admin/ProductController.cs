using Application.DTO.Admin;
using Application.DTO.Admin.Product;
using Core.IServices.Admin;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class ProductController(IProductService productService) : AdminController
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    [Route("GetProductList")]
    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList([FromBody] ProductGetList data)
    {
        return await _productService.GetList(data.SubCategoryId, data.Pagination, data.Filters, data.OrderBy);
    }

    [HttpPost]
    [Route("Product")]
    public async Task Add([FromBody] ProductAdd data)
    {
        await _productService.Add(
            data.SubcategoryId, 
            data.Name,
            data.Description1, 
            data.Description2, 
            data.Description3, 
            data.Price, 
            data.DescriptionPhoto1, 
            data.DescriptionPhoto2, 
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
            data.Description1, 
            data.Description2, 
            data.Description3, 
            data.Price, 
            data.DescriptionPhoto1, 
            data.DescriptionPhoto2, 
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
