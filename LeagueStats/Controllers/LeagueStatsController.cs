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

        [HttpGet("/summoners/{gameName}/{tagLine}")]
        public async Task<IActionResult> GetSummoner(string gameName, string tagLine)
        {
            var result = await _mediator.Send(new GetSummonerCommand(gameName, tagLine));

            return Ok(result);
        }

        [HttpGet("/matches/{quantity}/id/{id}")]
        public async Task<IActionResult> GetMatchesId(int quantity, string id)
        {
            var result = await _mediator.Send(new GetMatchesIdCommand(id, quantity));

            return Ok(result);
        }

        [HttpGet("/matches/{id}")]
        public async Task<IActionResult> GetMatchStats(string id)
        {
            var result = await _mediator.Send(new GetMatchStatsCommand(id));

            return Ok(result);
        }
    }
}
