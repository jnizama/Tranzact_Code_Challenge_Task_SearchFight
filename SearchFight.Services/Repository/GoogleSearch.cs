using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Services.Interfaces;
using SearchFight.Services.Models;
using SearchFight.Services.Models.Config;
using SearchFight.Transversal.Helpers;

namespace SearchFight.Services.Impl
{
    /// <summary>
    /// Implementation for Google
    /// </summary>
    public class GoogleSearch : ISearchEngine
    {
        #region Settings

        public string Name => "Google";        
        private HttpClient _client { get; }

        #endregion

        #region Constructors

        public GoogleSearch()
        {
            _client = new HttpClient();
        }

        #endregion

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = GoogleConfig.BaseUrl.Replace("{Key}", GoogleConfig.ApiKey)
                .Replace("{Context}", GoogleConfig.ContextId)
                .Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");

                GoogleResponse results = JsonHelper.Deserialize<GoogleResponse>(await response.Content.ReadAsStringAsync());
                return long.Parse(results.SearchInformation.TotalResults);
            }
        }
    }
}
