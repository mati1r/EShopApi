using Core.DTO.Core;
using Core.IServices.User;
using Core.Models.EShop;
using Core.Specifications.User.Histories;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Histories;

namespace Core.Services.UserServices;

public class HistoryService(
    IRepository<History> historyRepository
) : IHistoryService
{
    private readonly IRepository<History> _historyRepository = historyRepository;

    public async Task<SpecificationListAggregation<HistoryGetListSpecificationType>> GetList(int userId, AppPaginationList pagination, AppOrderByName orderBy)
    {
        var historyListSpec = new HistoryGetListSpecification(userId, orderBy);
        return await _historyRepository.AppListAsync(historyListSpec, pagination.PerPage, pagination.Page);
    }
}
