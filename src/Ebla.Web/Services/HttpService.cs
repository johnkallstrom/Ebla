﻿namespace Ebla.Web.Services
{
    public class HttpService<T> : IHttpService<T>
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed request - {url}, {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
        }

        public async Task<IEnumerable<T>> GetListAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed request - {url}, {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
            return result;
        }

        public async Task<T> PostAsync(string url, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed request - {url}, {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
        }

        public async Task<T> DeleteAsync(string url, object data)
        {
            var response = await _httpClient.DeleteAsJsonAsync(url, data);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed request - {url}, {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
        }
    }
}
