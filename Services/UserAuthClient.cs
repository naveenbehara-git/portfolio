using MyPortfolio.Model.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyPortfolio.Services
{
    public class UserAuthClient : IUserAuthClient
    {
        private readonly HttpClient _client;
        public UserAuthClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("user/login", request);
                //var json = response.Content.ReadAsStringAsync();
                if (response != null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LoginResponse result = JsonSerializer.Deserialize<LoginResponse>(content);
                    return result;
                }
                return null;
            }
            catch(Exception ex) { return null; }
        }
    }
}
