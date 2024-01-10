namespace Ebla.Web.Features.Statistics.Components
{
    public partial class GenrePieChart
    {
        [Inject]
        public IHttpService<Dictionary<string, double>> HttpService { get; set; }

        public bool Loading { get; set; } = true;
        public string[] Labels { get; set; }
        public double[] Data { get; set; }
        public int Count { get; set; } = 5;
        public int[] CountOptions { get; set; } = new int[] { 5, 10, 15, 20 }; 

        protected async override Task OnInitializedAsync() => await GetStatisticsDataAsync(Count);

        protected async Task GetStatisticsDataAsync(int selectedValue)
        {
            Count = selectedValue;

            var response = await HttpService.GetAsync($"{Endpoints.Statistics}/genres/{Count}");
            if (response is not null)
            {
                Data = response.Values.ToArray();
                Labels = FormatLabels(response.Keys.ToArray(), Data);
                Loading = false;
            }
        }

        private string[] FormatLabels(string[] labels, double[] percentages)
        {
            var formattedLabels = new List<string>();
            for (int i = 0; i < labels.Count(); i++)
            {
                string label = labels[i];
                double percentage = percentages[i];

                string newLabel = $"{label} ({percentage}%)";
                formattedLabels.Add(newLabel);
            }

            return formattedLabels.ToArray();
        }
    }
}
