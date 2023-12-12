namespace Ebla.Web.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, data);

            return response;
        }

        public Task<HttpResponseMessage> PutAsync(string uri, object data)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(string uri, T identifier)
        {
            throw new NotImplementedException();
        }
    }
}
