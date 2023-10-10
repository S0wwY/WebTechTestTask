using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebTechTestTask.Data.Data;
using WebTechTestTask.Data.Interfaces;
using WebTechTestTask.Models;

namespace WebTechTestTask.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext dataContext;
        public BaseRepository(DataContext DataContext)
        {
            this.dataContext = DataContext;
        }

        public void Delete(T entity) => dataContext.Set<T>().Remove(entity);

        public async Task<IList<T>> GetAllAsync() =>
            await dataContext.Set<T>().ToListAsync();

        public virtual async Task<T> GetByIdAsync(int id) =>
            await dataContext.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => dataContext.Set<T>().FirstOrDefaultAsync(predicate);

        public void Insert(T entity) => dataContext.Set<T>().Add(entity);

        public void Update(T entity) => dataContext.Set<T>().Update(entity);

        public async Task SaveAsync() => await dataContext.SaveChangesAsync();
    }
}
