using System.Linq.Expressions;
using WebTechTestTask.Models;

namespace WebTechTestTask.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task SaveAsync();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}