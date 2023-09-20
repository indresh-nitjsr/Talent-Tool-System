using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.Search.DTO;
using TalentToolSystem.Services.Search.Services;

namespace TalentToolSystem.Services.Search.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchCandidates(RequestDTO requestDTO)
        {
            try
            {
                List<ResponseDTO> results = await _searchService.SearchCandidates(requestDTO);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}
