using LeagueStats.Infrastructure.Models;
using Microsoft.Extensions.Logging;
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
    public class RiotClient<T> : IRiotClient<T> where T : RiotDTO
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RiotClient<T>> _logger;
        public RiotClient(HttpClient httpClient, ILogger<RiotClient<T>> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> Get(string endpoint)
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
