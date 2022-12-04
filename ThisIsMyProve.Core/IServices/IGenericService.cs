using System.Linq.Expressions;

namespace ThisIsMyProve.Core.IServices
{
    public interface IGenericService<T> where T : class
    {
        Task AddObjectAsync(T entity);
        void RemoveObject(T entity);
        Task<T?> GetObjectByIdAsync(int id);
        void UpdateObject(T entity);
        Task<IEnumerable<T>> GetAllObject();
        IQueryable<T> GetAllObjectWithQuery(Expression<Func<T, bool>> query);
        Task<T> FindObject(int id);
    }
}
