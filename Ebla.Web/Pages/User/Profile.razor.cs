namespace Ebla.Web.Pages.User
{
    public partial class Profile
    {
        [Parameter]
        public Guid UserId { get; set; }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"Parameter: {UserId}");
        }
    }
}