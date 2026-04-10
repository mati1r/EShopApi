using Application.DTO.Admin.FilterType;
using Application.DTO.Common;
using Core.IServices.Admin;
using Core.SpecificationTypes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin;

public class FilterTypeController(IFilterTypeService filterTypeService) : AdminController
{
    private readonly IFilterTypeService _filterTypeService = filterTypeService;

    [HttpGet]
    [Route("FilterType")]
    public async Task<SpecificationListAggregation<SelectListSpecificationType>> GetList([FromQuery] AppBasicContentControl data)
    {
        return await _filterTypeService.GetList(data.Pagination, data.OrderBy);
    }

    [HttpPost]
    [Route("FilterType")]
    public async Task Add([FromBody] FilterTypeAdd data)
    {
        await _filterTypeService.Add(data.Name);
    }

    [HttpPut]
    [Route("FilterType")]
    public async Task Update([FromBody] FilterTypeUpdate data)
    {
        await _filterTypeService.Update(data.Id, data.Name);
    }

    [HttpDelete]
    [Route("FilterType")]
    public async Task Delete([FromBody] FilterTypeDelete data)
    {
        await _filterTypeService.Delete(data.Id);
    }
}
