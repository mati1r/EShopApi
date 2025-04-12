using Application.DTO.Admin.Product;
using Core.IServices.Admin;
using Core.Specifications.Admin.Product;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class PoductController(IProductService productService) : AdminController
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    [Route("Product")]
    public async Task<List<ProductGetListSpecification>> GetList()
    {
        return await _productService.GetList();
    }

    [HttpPost]
    [Route("Product")]
    public async Task Add([FromBody] ProductAdd data)
    {
        await _productService.Add(
            data.SubcategoryId, 
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
            data.Description1, 
            data.Description2, 
            data.Description3, 
            data.Price, 
            data.DescriptionPhoto1, 
            data.DescriptionPhoto2, 
            data.Quantity, 
            data.Hidden
        );
    }

    [HttpDelete]
    [Route("Product")]
    public async Task Delete([FromBody] ProductDelete data)
    {
        await _productService.Delete(data.Id);
    }
}
