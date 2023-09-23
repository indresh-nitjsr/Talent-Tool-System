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

        [HttpGet]
        public async Task<IActionResult> SearchCandidates([FromQuery] RequestDTO requestDTO)
        {
            try
            {
                List<ResponseDTO> results = _searchService.SearchCandidates(requestDTO);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}
