using Microsoft.AspNetCore.Mvc;

namespace LeagueStats.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class LeagueStatsController : ControllerBase
    {
        public LeagueStatsController() { }

        [HttpGet("/match/{id}")]
        public IActionResult GetMatchStats(string id)
        {
            return Ok();
        }

    }
}
