using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Application.Repositories;
using DreamDriven.Persistance.Context;
using DreamDriven.Persistance.Repositories;

namespace DreamDriven.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();


        public int Save() => _context.SaveChanges();


        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        //Entity Framework Core'dan gelen ve veritabanındaki değişiklikleri asenkron olarak kaydeden bir metottur cancellationToken, uzun süren işlemlerin iptal edilmesini sağlar
        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
           => await _context.SaveChangesAsync(cancellationToken);

        // Hangi ReadRepository'ye aitse oraya gonder
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);


        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);

    }
}
