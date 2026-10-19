using MyPortfolio.Model;
using MyPortfolio.Model.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyPortfolio.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly HttpClient _client;
        public CandidateService(HttpClient client)
        {
            _client = client;
        }

        public async Task<StatusDTO> AddCandidateProfile(Candidate candidate)
        {
            try
            { 
                var response = await _client.PostAsJsonAsync("candidate/add", candidate);
                if (response != null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    StatusDTO result = JsonSerializer.Deserialize<StatusDTO>(content);
                    return result;
                }
                return null;
            }
            catch (Exception ex) { return null; }
        }

        public Task<StatusDTO> DeleteCandidateProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetCandidateProfileById(Guid userId)
        {
            try
            {
                var response = await _client.GetAsync($"candidate/get?UserId={userId}");
                if (response != null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    Candidate? result = JsonSerializer.Deserialize<Candidate>(content, options);
                    return result;
                }
                return null;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<StatusDTO> UpdateCandidateProfile(Candidate candidate)
        {
            try
            {
                var response = await _client.PutAsJsonAsync("candidate/update", candidate);
                if (response != null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    StatusDTO result = JsonSerializer.Deserialize<StatusDTO>(content);
                    return result;
                }
                return null;
            }
            catch (Exception ex) { return null; }
        }
        
    }
}
