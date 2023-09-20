using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.DemandAPI.Model;
using TalentToolSystem.Services.DemandAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentToolSystem.Services.DemandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IDemandService demandService;

        public DemandController(IDemandService demandService)
        {

            this.demandService = demandService;

        }

        // GET: api/<DemandController>
        [HttpGet("getdemandlist")]
        public async Task<List<Demand>> Get()
        {
            try
            {
                return await demandService.GetAllDemand();
            }
            catch
            {
                throw;
            }
        }

        // GET api/<DemandController>/5
        [HttpGet("getdemandbyid")]
        public async Task<IEnumerable<Demand>?> Get(int DemandId)
        {
            try
            {
                var response=await demandService.GetDemandById(DemandId);

                if(response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        // POST api/<DemandController>
        [HttpPost("adddemand")]
        public async Task<IActionResult> Post(Demand demand)
        {
            if(demand == null)
            {
                return BadRequest();
            }

            try
            {
                var result=await demandService.CreateDemand(demand);
                if(result == 0)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<DemandController>/5
        [HttpPut("updatedemand")]
        public async Task<IActionResult> Put(Demand demand)
        {
            if(demand == null)
            {
                return BadRequest();
            }

            try
            {
                var result=await demandService.UpdateDemand(demand);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/<DemandController>/5
        [HttpDelete("deletedemand")]
        public async Task<int> Delete(int demandid)
        {
            try
            {
                var response= await demandService.DeleteDemand(demandid);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
