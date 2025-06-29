﻿using Application.DTO.Anonymus;
using Core.IServices.Anonymus;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Anonymus;

public class ProductController(IProductService productService) : AnonymusController
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList([FromBody] ProductGetList data)
    {
        return await _productService.GetList(data.SubCategoryId, data.Pagination, data.Filters, data.OrderBy);
    }
}
