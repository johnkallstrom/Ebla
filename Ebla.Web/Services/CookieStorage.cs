namespace Ebla.Web.Services
{
    public class CookieStorage : ICookieStorage
    {
        private readonly IJSRuntime _jsRuntime;
        private IJSObjectReference _module;

        public CookieStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/services/cookieStorage.js");
        }

        public async Task SetAsync(string name, string value)
        {
            await _module.InvokeVoidAsync("set", new { Name = name, Value = value });
        }

        public async Task<string> GetAsync()
        {
            return await _module.InvokeAsync<string>("get");
        }
    }
}