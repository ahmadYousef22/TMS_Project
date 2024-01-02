using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Data;
using TrainingManagment.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TrainingManagment.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        //public IBaseRepository<Session> Sessions { get; private set; }
        public ISessionsRepository Sessions { get; private set; }

        public ILookupRepository lookups { get; private set; }

        // add more interfaces

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            //Sessions = new BaseRepository<Session>(_context);
            Sessions = new SessionsRepository(_context);
            lookups = new LookupRepository(_context);
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void DetachEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
