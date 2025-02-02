using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core;
using Core.SpecificationTypes.Core;

namespace Infrastracture.Data;

public class EntityFrameworkRepository<T>(DatabaseContext dbContext) : RepositoryBase<T>(dbContext), IReadRepositoryBase<T>, IRepository<T> where T : class
{
    public async Task<SpecificationListAggregation<TResult>> AppListAsync<TResult>(ISpecification<T, TResult> specification, int perPage, int page, CancellationToken cancellationToken = default)
    {
        var spec = new SpecificationListAggregation<TResult>
        {
            total = await CountAsync(specification, cancellationToken)
        };

        if (spec.total == 0) page = 1;
        else if (spec.total < page * perPage && page > 1)
        {
            page = (int)Math.Ceiling((double)spec.total / perPage);
        }

        int skip = (page - 1) * perPage;

        specification.Query
            .Skip(skip)
            .Take(perPage);

        spec.list = await ListAsync(specification, cancellationToken);

        spec.page = page;

        return spec;
    }

    public async Task<T?> GetByCompositeKeyAsync(params object[] keyValues)
    {
        return await dbContext.Set<T>().FindAsync(keyValues);
    }

    public void BeginTransaction()
    {
        dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        dbContext.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        dbContext.Database.RollbackTransaction();
    }
}
