namespace Ebla.Web.Pages.User
{
    public partial class MyLoans
    {
        [Parameter]
        public Guid UserId { get; set; }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"Parameter: {UserId}");
        }
    }
}
