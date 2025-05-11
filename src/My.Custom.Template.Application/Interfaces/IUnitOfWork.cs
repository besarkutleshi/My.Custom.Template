using My.Custom.Template.Common;
using My.Custom.Template.Common.DDD;

namespace My.Custom.Template.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T, TId> Repository<T, TId>() where T : AggregateRoot<TId> where TId : ValueObject;
    Task<int> SaveAsync(CancellationToken cancellationToken);
}
