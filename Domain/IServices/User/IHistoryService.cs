using Core.DTO.Core;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Histories;

namespace Core.IServices.User;

public interface IHistoryService
{
    public Task<SpecificationListAggregation<HistoryGetListSpecificationType>> GetList(int userId, AppPaginationList pagination, AppOrderByName orderBy);
}
