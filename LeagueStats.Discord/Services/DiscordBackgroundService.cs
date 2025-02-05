using Discord;
using Discord.Commands;
using Discord.WebSocket;
using LeagueStats.Discord.Configurations;
using LeagueStats.Discord.Facades;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeagueStats.Discord.Services
{
   public class DiscordBackgroundService : BackgroundService
   {
        private readonly DiscordSocketClient _client;
        private readonly DiscordBotConfig _config;
        private readonly IDiscordBotFacade _facade;

        public DiscordBackgroundService(IDiscordBotFacade facade, IOptions<DiscordBotConfig> config)
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent,
                LogLevel = LogSeverity.Info
            });
            _config = config.Value;
            _facade = facade;

            _client.Log += LogAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _client.LoginAsync(TokenType.Bot, _config.Token);
            
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.IsBot) return;
            if (!message.Content.StartsWith("!gandhi")) return;

            var parts = message.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                await message.Channel.SendMessageAsync("Uso correto: `!gandhi {nome} {tag}`");
                return;
            }

            var gameName = parts[1].Trim();
            var tagLine = parts[2].Trim();

            var  response = await _facade.GetStats(gameName, tagLine);

            var embed = new EmbedBuilder()
                .WithTitle("Gandhi está pacientemente lendo os dados...")
                .WithDescription(string.Join("\n", response.Select(x => $"Nome: {x.GameName} | Lane: {x.Lane} | Champion: {x.Champion} | Dano: {x.DamageDealt} | Dano Sofrido: {x.DamageTaken} " + $"| Pinks: {x.StealthWardsPlaced} | Skillshots desviadas: {x.SkillshotsDodged} | KDA: {Math.Round(x.Kda, 2)} | DPM : {Math.Round(x.DamagePerMinute, 2)}\n\n")))
                .WithColor(Color.Blue)
                .Build();

            await message.Channel.SendMessageAsync(embed: embed);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        
    }

}
