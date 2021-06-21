﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Services.Interfaces;
using SearchFight.Services.Models;
using SearchFight.Services.Models.Config;
using SearchFight.Transversal.Helpers;

namespace SearchFight.Services.Repository
{
    /// <summary>
    /// Implementation for MSN Search
    /// </summary>
    public class BingSearch : ISearchEngine
    {
        #region Settings

        public string Name => "MSN Search";        
        private HttpClient _client { get; }               

        #endregion

        #region Constructors

        public BingSearch()
        {
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", BingConfig.ApiKey } } };            
        }

        #endregion

        #region Interface Methods

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = BingConfig.BaseUrl.Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");
                
                BingResponse results = JsonHelper.Deserialize<BingResponse>(await response.Content.ReadAsStringAsync());                
                return long.Parse(results.WebPages.TotalEstimatedMatches);
            }
        }

        #endregion
    }
}
