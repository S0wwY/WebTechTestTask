using WebTechTestTask.Application.Interfaces;
using WebTechTestTask.Application.ViewModels.Mapping;
using WebTechTestTask.Application.ViewModels.UserViewModels;
using WebTechTestTask.Data.Interfaces;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task AddRoleForUser(int userId, ICollection<int> newRolesIds)
        {
            await IsUserExistAsync(userId);

            var userEntity = await _userRepository.GetByIdAsync(userId);
            var roles = await _roleRepository.GetRolesByIdsAsync(newRolesIds);

            foreach(var role in roles)
            {
                if(userEntity != null && !userEntity.Roles.Contains(role))
                {
                    userEntity.Roles.Add(role);
                } 
                else
                {
                    throw new ArgumentException("The user already has this role");
                }
            }

            _userRepository.Update(userEntity);
            await _userRepository.SaveAsync();
        }

        public async Task CreateUserAsync(UserForCreationVm newUser)
        {
            await ValidateEmailAsync(newUser.Email);

            var roles = await _roleRepository.GetRolesByIdsAsync(newUser.RolesIds);
            var userEntity = UserProfile.ToUserModel(newUser, roles);
            
            _userRepository.Insert(userEntity);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserByIdAsync(int userId)
        {
            await IsUserExistAsync(userId);

            var user = await _userRepository.GetByIdAsync(userId);

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }

        public async Task<PagedList<UserVm>> GetFilteredUsersAsync(UserParameters parameters)
        {
            var pagedUsers = await _userRepository.GetWithFiltersAsync(parameters);

            var pagedUsersVm = UserProfile.ToUserViewModel(pagedUsers); // спросить геру где лучше тут или в репо ?

            return pagedUsersVm;
        }

        public async Task<UserVm> GetUserByIdAsync(int userId)
        {
            await IsUserExistAsync(userId);

            var user = await _userRepository.GetByIdAsync(userId);

            var userVm = UserProfile.ToUserViewModel(user);

            return userVm;
        }

        public async Task UpdateUserAsync(int id, UserForUpdateVm updatedUser)
        {
            await IsUserExistAsync(id);

            await ValidateEmailAsync(updatedUser.Email);

            var oldUser = await _userRepository.GetByIdAsync(id);

            //var userEntity = UserProfile.ToUserModel()
            oldUser.Age = updatedUser.Age;
            oldUser.Email = updatedUser.Email;
            oldUser.Name = updatedUser.Name;
            //роли?
            
            _userRepository.Update(oldUser);
            await _userRepository.SaveAsync();
        }

        protected async Task ValidateEmailAsync(string email)
        {
            if (await _userRepository.IsEmailExist(email))
            {
                throw new ArgumentException($"User with email {email} already exists.");
            }
        }

        protected async Task IsUserExistAsync(int userId)
        {
            if (await _userRepository.GetByIdAsync(userId) == null)
            {
                throw new KeyNotFoundException($"user with id: {userId}, not found");
            }
        }

    }
}
