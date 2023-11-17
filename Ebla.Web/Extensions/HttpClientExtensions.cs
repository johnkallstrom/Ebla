namespace Ebla.Web.Extensions
{
    public static class HttpClientExtensions
    {
        public static void SetAuthorizationHeaderWithToken(this HttpClient httpClient, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}