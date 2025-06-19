using Application.DTO.User;
using Core.Exceptions;
using Core.IServices.User;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Histories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.User;

public class HistoryController(IHistoryService historyService) : UserController
{
    private readonly IHistoryService _historyService = historyService;

    [HttpGet("GetList")]
    public async Task<SpecificationListAggregation<HistoryGetListSpecificationType>> GetList([FromQuery] HistoryGetList data)
    {
        if (CurrentUserId is null)
            throw new AppErrorException("Could not get currently loged in user");

        return await _historyService.GetList(
            (int)CurrentUserId,
            data.Pagination,
            data.OrderBy
        );
    }
}
