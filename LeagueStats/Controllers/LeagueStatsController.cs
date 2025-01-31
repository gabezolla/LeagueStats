using LeagueStats.Application.Commands;
using LeagueStats.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeagueStats.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class LeagueStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeagueStatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/summoner/{gameName}/{tagLine}")]
        public async Task<IActionResult> GetSummoner(string gameName, string tagLine)
        {
            var result = await _mediator.Send(new GetSummonerCommand(gameName, tagLine));

            return Ok(result);
        }

        [HttpGet("/match/{id}")]
        public async Task<IActionResult> GetMatchStats(string id)
        {
            return Ok();
        }

    }
}
