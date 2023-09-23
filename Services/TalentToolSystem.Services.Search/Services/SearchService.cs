using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public List<ResponseDTO> SearchCandidates(RequestDTO requestDTO)
        {
            try
            {
                var filteredCandidates = GetAllCandidates();

                if (!string.IsNullOrEmpty(requestDTO.Account))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Account == requestDTO.Account).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.CandidateName))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.CandidateName == requestDTO.CandidateName).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Manager))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Manager == requestDTO.Manager).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Status))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Status == requestDTO.Status).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Location))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Location == requestDTO.Location).ToList();
                }

                if (requestDTO.ReferralId.HasValue)
                {
                    filteredCandidates = filteredCandidates.Where(c => c.ReferralId == requestDTO.ReferralId).ToList();
                }

                return filteredCandidates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchCandidates: {ex.Message}");
                throw;
            }
        }

        private List<ResponseDTO> GetAllCandidates()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.Timeout = TimeSpan.FromMinutes(5);

                var searchResults = new List<ResponseDTO>();

                var candidateResponse = httpClient.GetAsync("https://localhost:7095/api/Candidate/getcandidatelist").Result;

                if (candidateResponse.IsSuccessStatusCode)
                {
                    candidateResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var responseJson = candidateResponse.Content.ReadAsStringAsync().Result;
                    var candidates = JsonConvert.DeserializeObject<List<ResponseDTO>>(responseJson);
                    searchResults.AddRange(candidates);
                }
                else
                {
                    Console.WriteLine("Error in GetAllCandidates: HTTP request failed.");
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllCandidates: {ex.Message}");
                throw; 
            }
        }
    }
}
