using WebTechTestTask.Models;

namespace WebTechTestTask.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(Login user);
    }
}
