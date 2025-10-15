using Microsoft.EntityFrameworkCore;
using MyCMS.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.DataAccess.Services
{
    //public class Service<T> : IService<T> where T : class
    public class Service<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Service(MyDbContext context)
        {
            _context=context;
            _dbSet=_context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }        

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteById(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<T> GetAllUsers(int pageId, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(object? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public int PageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
