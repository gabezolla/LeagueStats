using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Clients
{
    public class RiotClient : IRiotClient
    {
        private readonly HttpClient _httpClient;
        private readonly RiotClientConfig _config;   
        private readonly ILogger<RiotClient> _logger;

        public RiotClient(IOptions<RiotClientConfig> config, HttpClient httpClient, ILogger<RiotClient> logger)
        {
            _httpClient = httpClient;
            _config = config.Value;

            _httpClient.BaseAddress = new Uri(_config.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _config.ApiKey);

            _logger = logger;
        }

        public async Task<T> Get<T>(string endpoint) where T : class
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _logger.LogInformation("Starting GET request for {endpoint}", endpoint);

            var response = await _httpClient.GetAsync(endpoint);

            if (response == default || !response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"HTTP request to {endpoint} failed with status {response?.StatusCode}");
            }

            _logger.LogInformation("GET Request to {endpoint} finished after {elapsed} with status", endpoint, stopwatch.Elapsed);

            var result = await response.Content.ReadFromJsonAsync<T>();

            if (result == null)
            {
                throw new HttpRequestException($"Failed to deserialize response from {endpoint}.");
            }

            return result;
        }
    }
}
