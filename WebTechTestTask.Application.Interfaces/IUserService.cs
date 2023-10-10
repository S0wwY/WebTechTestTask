using WebTechTestTask.Application.ViewModels.UserViewModels;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedList<UserVm>> GetFilteredUsersAsync(UserParameters parameters);
        Task<UserVm> GetUserByIdAsync(int userId);
        Task AddRoleForUser (int userId, ICollection<int> newRolesIds);
        Task CreateUserAsync(UserForCreationVm newUser);
        Task UpdateUserAsync(int id, UserForUpdateVm updatedUser);
        Task DeleteUserByIdAsync(int userId);
    }
}
