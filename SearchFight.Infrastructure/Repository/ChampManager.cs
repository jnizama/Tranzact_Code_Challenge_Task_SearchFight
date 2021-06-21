using System;
using System.Linq;
using System.Collections.Generic;
using SearchFight.Infrastructure.Interfaces;
using SearchFight.Infrastructure.Models;
using SearchFight.Transversal.Extensions;

namespace SearchFight.Infrastructure.Repository
{
    public class ChampManager : IChampManager
    {
        public SearchEngineChampion GetGrandWinner(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            Search searchWinner = searchData.GetMax(item => item.Results);
            return new SearchEngineChampion() { Engine = searchWinner.SearchEngine, Term = searchWinner.Term };
        }

        public IEnumerable<SearchEngineChampion> GetSearchEngineWinners(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            IEnumerable<SearchEngineChampion> searchEngines = searchData.GroupBy(data => data.SearchEngine,
                result => result, (searchEngine, results) => new SearchEngineChampion
                {
                    Engine = searchEngine,
                    Term = results.GetMax(item => item.Results).Term
                });

            return searchEngines;
        }
    }
}
