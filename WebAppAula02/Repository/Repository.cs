using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAppAula02.Data;
using WebAppAula02.Repository.Interfaces;
using WebAppAula02.Models;


namespace WebAppAula02.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Base, new()
    {
        protected readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public virtual async Task Remove(int id)
        {
            _context.Remove((object)new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
