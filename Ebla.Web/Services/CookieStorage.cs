namespace Ebla.Web.Services
{
    public class CookieStorage : ICookieStorage
    {
        private readonly IJSRuntime _jsRuntime;

        public CookieStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetAsync(string name, string value)
        {
            await _jsRuntime.InvokeVoidAsync("set", new { Name = name, Value = value });
        }

        public Task<string> GetAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}