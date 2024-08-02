﻿using DreamDriven.Application.Interfaces.UnitOfWorks;
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

        // Hangi ReadRepository'ye aitse oraya gonder
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);


        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);

    }
}
