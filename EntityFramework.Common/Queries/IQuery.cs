using System.Linq;
using EntityFramework.Common.Entities;

namespace EntityFramework.Common.Queries
{
    public interface IQuery<T>
        where T : IBaseEntity
    {
        IQueryable<T> ApplyPredicate(IQueryable<T> inputSet);
    }

    public interface IQuery<in TInput, out TOutput>
        where TInput : IBaseEntity
        where TOutput : IBaseEntity
    {
        IQueryable<TOutput> ApplyPredicate(IQueryable<TInput> inputSet);
    }
}