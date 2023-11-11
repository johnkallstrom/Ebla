﻿namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginViewModel ViewModel { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            var result = await UserHttpService.LoginUserAsync(ViewModel.Username, ViewModel.Password);

            if (result.Succeeded)
            {
                await LocalStorage.SetItemAsStringAsync("token", result.Data);
                NavigationManager.ReloadStartPage();
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }
    }
}