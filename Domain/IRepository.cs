using Ardalis.Specification;
using Core.SpecificationTypes.Core;

namespace Core;

public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class
{
    Task<SpecificationListAggregation<TResult>> AppListAsync<TResult>(ISpecification<T, TResult> specification, int perPage, int page, CancellationToken cancellationToken = default);
    Task<T?> GetByCompositeKeyAsync(params object[] keyValues);
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
