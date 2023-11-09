namespace Ebla.Web.Pages
{
    public partial class Start
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public bool IsAuthorized { get; set; }
        public string Token { get; set; }

        protected override async Task OnInitializedAsync()
        {
            string token = await LocalStorage.GetItemAsStringAsync("token");
            if (!string.IsNullOrEmpty(token))
            {
                IsAuthorized = true;
                Token = token;
            }

            // Todo: also check if token has expired
        }
    }
}
