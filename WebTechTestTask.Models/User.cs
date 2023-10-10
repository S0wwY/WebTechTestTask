namespace WebTechTestTask.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public ICollection<Role>? Roles { get; set; }
    }
}