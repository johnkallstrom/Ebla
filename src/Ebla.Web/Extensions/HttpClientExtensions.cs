namespace Ebla.Web.Extensions
{
    public static class HttpClientExtensions
    {
        public static void SetAuthorizationHeader(this HttpClient httpClient, string scheme, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, value);
            }
        }

        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<TValue>(this HttpClient httpClient, string requestUri, TValue value)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{requestUri}"),
                Method = HttpMethod.Delete,
                Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);
            return response;
        }
    }
}