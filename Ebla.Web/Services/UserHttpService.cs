﻿namespace Ebla.Web.Services
{
    public class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginUserAsync(string username, string password)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
            return await httpResponse.Content.ReadFromJsonAsync<LoginResponse>();
        }
    }
}
