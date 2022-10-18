using System.Linq.Expressions;
using WebAppAula02.Models;

namespace WebAppAula02.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Base
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(int id);

        Task<int> SaveChanges();

    }
}

