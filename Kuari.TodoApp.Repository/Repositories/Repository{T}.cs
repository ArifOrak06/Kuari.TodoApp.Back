using Kuari.TodoApp.Core.Repositories;
using Kuari.TodoApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TodoAppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TodoAppDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            if (data != null)
            {
                _context.Entry(data).State = EntityState.Detached;
               
            }
            return data;
        }

        public async void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
