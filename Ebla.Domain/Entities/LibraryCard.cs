namespace Ebla.Domain.Entities
{
    public class LibraryCard : BaseEntity<int>
    {
        public DateTime Expires { get; set; }

        // User Reference
        public Guid? UserId { get; set; }
    }
}