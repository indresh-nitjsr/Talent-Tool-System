using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TalentToolSystem.Services.Search.DTO;

namespace TalentToolSystem.Services.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ResponseDTO>> SearchCandidates(RequestDTO requestDTO)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var searchResults = new List<ResponseDTO>();

                var requestContent = new StringContent(JsonConvert.SerializeObject(requestDTO), Encoding.UTF8, "application/json");

                var candidateResponse = await httpClient.PostAsync("https://localhost:7095/api/candidate/search", requestContent);

                if (candidateResponse.IsSuccessStatusCode)
                {
                    candidateResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var candidateDetails = await candidateResponse.Content.ReadFromJsonAsync<ResponseDTO>();
                    searchResults.Add(candidateDetails);
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
