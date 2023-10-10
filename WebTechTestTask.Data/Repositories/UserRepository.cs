using Microsoft.EntityFrameworkCore;
using WebTechTestTask.Data.Data;
using WebTechTestTask.Data.Extensions;
using WebTechTestTask.Data.Interfaces;
using WebTechTestTask.Models;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        
        }

        public override async Task<User> GetByIdAsync(int id) =>
            await dataContext.Set<User>().Where(u => u.Id == id)
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync();

        public async Task<PagedList<User>> GetWithFiltersAsync(UserParameters userParameters)
        {
            var userEntity = dataContext.Set<User>().Include(u => u.Roles);

            var users = await userEntity.FilterByName(userParameters.Name)
                               .FilterByEmail(userParameters.Email)
                               .FilterByAge(userParameters.Age)
                               .FilterByRole(userParameters.Role)
                               .Sort(userParameters.OrderParameters)
                               .ToListAsync();

            return PagedList<User>.ToPagedList(users,
                  userParameters.PageNumber,
                  userParameters.PageSize);
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await dataContext.Users.FirstOrDefaultAsync(u => u.Email == email) != null;
        }
    }
}
