namespace Ebla.Web.Features.Statistics.Components
{
    public partial class Totals
    {
        [Inject]
        public IHttpService<Dictionary<string, int>> HttpService { get; set; }

        public bool Loading { get; set; } = true;
        public int Books { get; set; }
        public int Users { get; set; }
        public int Loans { get; set; }
        public int Reservations { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var data = await HttpService.GetAsync($"{Endpoints.Statistics}/totals");
            if (data is not null)
            {
                foreach (var total in data)
                {
                    switch (total.Key)
                    {
                        case "books":
                            Books = total.Value;
                            break;
                        case "users":
                            Users = total.Value;
                            break;
                        case "loans":
                            Loans = total.Value;
                            break;
                        case "reservations":
                            Reservations = total.Value;
                            break;
                    }
                }

                Loading = false;
            }
        }
    }
}
