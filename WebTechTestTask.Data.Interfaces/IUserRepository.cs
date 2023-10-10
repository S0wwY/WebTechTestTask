using WebTechTestTask.Models;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<PagedList<User>> GetWithFiltersAsync(UserParameters postParameters);
        Task<bool> IsEmailExist(string email);
    }
}
