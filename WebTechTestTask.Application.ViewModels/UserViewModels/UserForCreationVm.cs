using System.ComponentModel.DataAnnotations;

namespace WebTechTestTask.Application.ViewModels.UserViewModels
{
    public class UserForCreationVm
    {
        [Required(ErrorMessage = "UserName is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is a required field")]
        [Range(0, 100, ErrorMessage = "Age is required and it can't be lower 0 and more than 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is a required field")]
        public string Email { get; set; }

        public ICollection<int>? RolesIds { get; set; }
    }
}
