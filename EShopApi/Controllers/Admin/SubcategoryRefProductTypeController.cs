using Application.DTO.Admin.SubcategoryRefProductType;
using Core.IServices.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class SubcategoryRefProductTypeController(ISubcategoryRefProductTypeService subcategoryRefProductTypeService) : AdminController
{
    private readonly ISubcategoryRefProductTypeService _subcategoryRefProductTypeService = subcategoryRefProductTypeService;

    [HttpPost]
    [Route("SubcategoryRefProductType")]
    public async Task Add([FromBody] SubcategoryRefProductTypeAdd data)
    {
        await _subcategoryRefProductTypeService.Add(data.SubcategoryId, data.ProductTypeId);
    }

    [HttpDelete]
    [Route("SubcategoryRefProductType")]
    public async Task Delete([FromBody] SubcategoryRefProductTypeDelete data)
    {
        await _subcategoryRefProductTypeService.Delete(data.SubcategoryId, data.ProductTypeId);
    }
}
