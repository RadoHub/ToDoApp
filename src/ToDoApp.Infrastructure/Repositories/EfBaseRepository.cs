using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
    public class EfBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public EfBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => EF.Property<Guid>(e, "Id")==id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter != null ? _dbSet.Where(filter) : _dbSet;
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
