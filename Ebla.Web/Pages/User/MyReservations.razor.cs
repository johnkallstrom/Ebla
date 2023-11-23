namespace Ebla.Web.Pages.User
{
    public partial class MyReservations
    {
        [Parameter]
        public Guid UserId { get; set; }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"Parameter: {UserId}");
        }
    }
}
