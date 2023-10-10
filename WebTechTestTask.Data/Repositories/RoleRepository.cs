using Microsoft.EntityFrameworkCore;
using WebTechTestTask.Data.Data;
using WebTechTestTask.Data.Interfaces;
using WebTechTestTask.Models;

namespace WebTechTestTask.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {

        }

        public async Task<ICollection<Role>> GetRolesByIdsAsync(ICollection<int> ids)
        {
            if(!dataContext.Roles.Any(r => ids.Contains(r.Id)))
            {
                throw new KeyNotFoundException("there are no roles with this id");
            }

            var roles = await dataContext.Roles.Where(r => ids.Contains(r.Id)).ToListAsync();

            return roles;
        }
    }
}
