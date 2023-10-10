using WebTechTestTask.Data.Extensions.Utility;
using WebTechTestTask.Models;
using System.Linq.Dynamic.Core;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace WebTechTestTask.Data.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> FilterByName(this IQueryable<User> users, string userName)
        {
            if (userName == null)
            {
                return users;
            }

            return users.Where(u => u.Name.Contains(userName));
        }

        public static IQueryable<User> FilterByAge(this IQueryable<User> users, int age)
        {
            if (age <= 0)
            {
                return users;
            }

            return users.Where(u => u.Age == age);
        }

        public static IQueryable<User> FilterByEmail(this IQueryable<User> users, string email)
        {
            if (email.IsNullOrEmpty())
            {
                return users;
            }

            return users.Where(u => u.Email.Contains(email));

        }

        public static IQueryable<User> FilterByRole(this IQueryable<User> users, string roleName)
        {
            if (roleName.IsNullOrEmpty())
            {
                return users;
            }

            return users.Where(u => u.Roles.Any(r => r.RoleName.Contains(roleName)));
        }

        public static IQueryable<User> Sort(this IQueryable<User> users, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return users.OrderBy(u => u.Name);
            }

            if (orderByQueryString.Contains("age"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    users.OrderByDescending(u => u.Age) :
                    users.OrderBy(u => u.Age);
            }

            if (orderByQueryString.Contains("email"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    users.OrderByDescending(u => u.Email) :
                    users.OrderBy(u => u.Email);
            }

            if (orderByQueryString.Contains("role"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    users.OrderByDescending(u => u.Roles) :
                    users.OrderBy(u => u.Roles);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<User>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return users.OrderBy(p => p.Name);
            }

            return users.OrderBy(orderQuery);
        }
    }
}
