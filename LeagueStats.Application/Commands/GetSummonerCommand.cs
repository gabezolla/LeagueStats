using LeagueStats.Domain.Entities;
using MediatR;

namespace LeagueStats.Application.Commands
{
    public class GetSummonerCommand : IRequest<Summoner> // TODO: Change to SummonerViewModel
    {
        public GetSummonerCommand(string gameName, string tagLine)
        {
            GameName = gameName;
            TagLine = tagLine;
        }

        public string GameName { get; set; }

        public string TagLine { get; set; }

    }
}
