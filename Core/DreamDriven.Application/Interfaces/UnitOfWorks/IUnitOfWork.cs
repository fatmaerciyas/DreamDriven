using DreamDriven.Application.Repositories;
using DreamDriven.Domain.Common;

namespace DreamDriven.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync(CancellationToken cancellationToken);
        int Save(); //asenkron olmayan save islemleri icin
    }
}
