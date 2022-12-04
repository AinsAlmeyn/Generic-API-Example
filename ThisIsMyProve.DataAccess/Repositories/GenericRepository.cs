using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ThisIsMyProve.Core.IRepositories;

namespace ThisIsMyProve.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly thisIsMyProveDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(thisIsMyProveDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddObjectAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void RemoveObject(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<T?> GetObjectByIdAsync(int id)
        {
            var fValue = _dbSet.FindAsync(id);
            return await fValue;
        }

        public void UpdateObject(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllObject()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAllObjectWithQuery(Expression<Func<T, bool>> query)
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> FindObject(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
