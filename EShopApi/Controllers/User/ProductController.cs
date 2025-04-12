using Application.DTO.User;
using Core.IServices.User;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Product;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.User;

public class ProductController(IProductService productService) : UserController
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList([FromQuery] ProductGetList data)
    {
        return await _productService.GetList(data.SubCategoryId, data.Pagination, data.Filters, data.OrderBy);
    }
}
