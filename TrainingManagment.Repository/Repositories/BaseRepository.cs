using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Domain.consts;
using TrainingManagment.Repository.Data;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Repositories;

namespace TrainingManagment.Repository.Repositories
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
         protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<T> GetByIdAsync(int id)
        {
 
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (DbUpdateException ex)
            {
                throw new DataAccessException("An error occurred while fetching an entity by ID.", ex);
            }
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while fetching all entities.", ex);
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DataAccessException("An error occurred while saving data.", ex);
            }
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return entities;
            }
            catch (Exception ex)
            {

                throw new DataAccessException("An error occurred while saving data.", ex);
            }
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            try
            {
                return await _context.Set<T>().SingleOrDefaultAsync(criteria);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }

        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.SingleOrDefaultAsync(criteria);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }



        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.Where(criteria).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new DataAccessException("An error occurred while finding the entity.", ex);

            }
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            try
            {

                return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new DataAccessException("An error occurred while finding the entity.", ex);

            }
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
           Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().Where(criteria);

                if (take.HasValue)
                    query = query.Take(take.Value);// to ensure it's not null

                if (skip.HasValue)
                    query = query.Skip(skip.Value);

                if (orderBy != null)
                {
                    if (orderByDirection == OrderBy.Ascending)
                        query = query.OrderBy(orderBy);
                    else
                        query = query.OrderByDescending(orderBy);
                }

                return await query.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new DataAccessException("An error occurred while finding the entity.", ex);

            }
        }


        public T Update(T entity)
        { 
        try
    {
        var entry = _context.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
    }

    entry.State = EntityState.Modified;
        
        return entity;
    }
    catch (Exception ex)
    {
    throw new DataAccessException("An error occurred while updating the entity.", ex);
}
        }

        public void UpdateRange(List<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }

        public void HardDelete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }

        public void Attach(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().AttachRange(entities);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }
        public async Task<int> CountAsync()
        {
            try
            {
                return await _context.Set<T>().CountAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            try
            {
                return await _context.Set<T>().CountAsync(criteria);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while finding the entity.", ex);
            }
        }
    }

}
