using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Data.Interfaces;

namespace Xayah.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly SqlServerContext context;
        protected readonly DbSet<T> _dbSet;
        public Repository(SqlServerContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> GetById(Guid id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> Insert(T obj)
        {
            try
            {
                await _dbSet.AddAsync(obj);
                await SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task Update(Guid id, T obj)
        {
            try
            {
                _dbSet.Update(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task Delete(Guid id)
        {
            try
            {
                T obj = await GetById(id);
                if (obj != null)
                {
                    _dbSet.Remove(obj);
                    await SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
