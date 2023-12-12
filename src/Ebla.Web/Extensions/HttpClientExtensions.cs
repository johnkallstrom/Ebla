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
    }
}