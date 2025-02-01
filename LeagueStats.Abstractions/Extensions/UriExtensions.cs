using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Abstractions.Extensions
{
    public static class UriExtensions
    {
        public static string AddQueryParameters(this string path, Dictionary<string, string> queryParams)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            
            return string.Concat(path, "?", queryString);
            
        }
    }
}
