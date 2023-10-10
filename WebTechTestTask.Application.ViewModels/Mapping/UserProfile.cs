using WebTechTestTask.Application.ViewModels.UserViewModels;
using WebTechTestTask.Models;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Application.ViewModels.Mapping
{
    public class UserProfile
    {
        public static User ToUserModel(UserForCreationVm userVm, ICollection<Role> roles)
        {
            User user = new User()
            {
                Age = userVm.Age,
                Email = userVm.Email,
                Name = userVm.Name,
                Roles = roles
            };

            return user;
        }

        public static User ToUserModel(UserForUpdateVm userVm, ICollection<Role> roles)
        {
            User user = new User()
            {
                Age = userVm.Age,
                Email = userVm.Email,
                Name = userVm.Name,
                Roles = roles
            };

            return user;
        }

        public static UserVm ToUserViewModel(User user)
        {
            UserVm userVm = new UserVm()
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                RolesName = user.Roles.Select(r => r.RoleName).ToList()
            };
        
            return userVm;
        }

        public static PagedList<UserVm> ToUserViewModel(PagedList<User> users)
        {
            PagedList<UserVm> userVms = new PagedList<UserVm>();

            foreach (var user in users)
            {
                userVms.Add(new UserVm
                {
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                    RolesName = user.Roles.Select(r => r.RoleName).ToList()
                });
            }

            return userVms;
        }
    }
}
