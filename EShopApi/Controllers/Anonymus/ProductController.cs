using Application.DTO.Anonymus;
using Application.Helpers;
using Core.DTO.Core;
using Core.IServices.Anonymus;
using Core.IServices.Infrastructure;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Anonymus;

public class ProductController(IProductService productService, IStorageService storageService) : AnonymusController
{
    private readonly IProductService _productService = productService;
    private readonly IStorageService _storageService = storageService;

    [HttpPost]
    [Route("GetList")]
    public async Task<SpecificationListAggregation<ProductGetListSpecificationType>> GetList([FromBody] ProductGetList data)
    {
        return await _productService.GetList(data.SubCategoryId, data.Pagination, data.Filters, data.OrderBy);
    }

    [HttpPost]
    [Route("FileUploadTest")]
    public async Task FileUploadTest([FromForm] FileUploadTest data)
    {
        var file = await FileHelper.ConvertIFormFileToFileModelAsync(data.File);

        await _storageService.Upload(data.FilePath, file.Content);
    }
}
