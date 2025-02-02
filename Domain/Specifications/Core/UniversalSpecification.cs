using System.Linq.Expressions;
using Ardalis.Specification;

namespace Core.Specifications.Core
{
    public class UniversalSpecification<T> : Specification<T> where T : class
    {
        public UniversalSpecification(Expression<Func<T, bool>>? filter = null)
        {
            if (filter != null)
            {
                Query.Where(filter);
            }
        }

        public UniversalSpecification<T> AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Query.Include(includeExpression);
            return this;
        }

        public UniversalSpecification<T> GetMax(Expression<Func<T, object?>> includeExpression)
        {
            Query.OrderByDescending(includeExpression);
            return this;
        }

        public UniversalSpecification<T> AddAsNoTracking()
        {
            Query.AsNoTracking();
            return this;
        }

        public UniversalSpecification<T> AddAsSplitQuery()
        {
            Query.AsSplitQuery();
            return this;
        }
    }
    public class UniversalSpecification<T, TResult> : Specification<T, TResult>
    {
        public UniversalSpecification(Expression<Func<T, bool>>? filter = null, Expression<Func<T, TResult>>? selector = null)
        {
            if (filter != null)
            {
                Query.Where(filter);
            }

            if (selector != null)
            {
                Query.Select(selector);
            }
        }

        public UniversalSpecification<T, TResult> GetMax(Expression<Func<T, object?>> includeExpression)
        {
            Query.OrderByDescending(includeExpression);
            return this;
        }
    }
}
