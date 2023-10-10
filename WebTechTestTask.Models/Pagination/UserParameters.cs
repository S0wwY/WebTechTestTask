namespace WebTechTestTask.Models.Pagination
{
    public class UserParameters : QueryStringParameters
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string OrderParameters { get; set; } = "asc";
        public string? Role { get; set; }

    }
}
