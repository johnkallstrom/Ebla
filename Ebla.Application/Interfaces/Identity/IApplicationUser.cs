namespace Ebla.Application.Interfaces.Identity
{
    public interface IApplicationUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}