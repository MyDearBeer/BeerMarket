namespace Identity.Backend.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
