namespace Ebla.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}