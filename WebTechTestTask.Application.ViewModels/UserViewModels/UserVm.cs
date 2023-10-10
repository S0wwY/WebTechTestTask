namespace WebTechTestTask.Application.ViewModels.UserViewModels
{
    public class UserVm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public ICollection<string> RolesName { get; set; }
    }
}
