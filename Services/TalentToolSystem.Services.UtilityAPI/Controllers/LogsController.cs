using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.UtilityAPI.Data;
using TalentToolSystem.Services.UtilityAPI.Models;
using TalentToolSystem.Services.UtilityAPI.Repository;

namespace TalentToolSystem.Services.UtilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        readonly ILogRepository _logRepository;
        public LogsController(ILogRepository logRepository)
        {
            this._logRepository = logRepository;
        }

        [HttpGet("GetAllCandidateLogs")]
        public IActionResult GetAllCandidateLogs()
        {
            var result = _logRepository.GetAllCandidateLogs();
            return Ok(result);
        }
    }
}
