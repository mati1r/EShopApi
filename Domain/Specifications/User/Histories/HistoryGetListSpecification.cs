using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums;
using Core.Models.EShop;
using Core.SpecificationTypes.Core;
using Core.SpecificationTypes.User.Histories;

namespace Core.Specifications.User.Histories;

public class HistoryGetListSpecification : Specification<History, HistoryGetListSpecificationType>
{
    public HistoryGetListSpecification(int userId, AppOrderByName orderBy)
    {
        Expression<Func<History, object?>> orderByExpression = orderBy.OrderByName switch
        {
            "created" => h => h.CreatedAt,
            "sumPrice" => h => h.SumPrice,
            "payment" => h => h.PaymentType.Name,
            _ => h => h.Id
        };

        var query = Query
            .Select(h => new HistoryGetListSpecificationType
            {
                HistoryId = h.Id,
                CreatedAt = h.CreatedAt,
                SumPrice = h.SumPrice,
                PaymentTypeName = h.PaymentType.Name,
                ProductNames = h.ProductRefHistories.Select(prh => prh.Product.Name).ToList()
            }).Where(h => h.UserId == userId);

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) query.OrderBy(orderByExpression);
        if (orderBy.OrderDirection == OrderDirectionEnum.Desc) query.OrderByDescending(orderByExpression);

        query.AsTracking();
    }
}
