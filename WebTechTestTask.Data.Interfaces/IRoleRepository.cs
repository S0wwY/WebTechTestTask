using WebTechTestTask.Models;

namespace WebTechTestTask.Data.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role> 
    {
        Task<ICollection<Role>> GetRolesByIdsAsync(ICollection<int> ids);
    }
}
