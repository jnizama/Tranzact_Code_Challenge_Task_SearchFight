using System.Collections.Generic;
using SearchFight.Infrastructure.Models;


namespace SearchFight.Infrastructure.Interfaces
{
    public interface IChampManager
    {
        /// Get winners by engine.
        IEnumerable<SearchEngineChampion> GetSearchEngineWinners(IList<Search> searchData);

        /// Get winner from all the search data.
        SearchEngineChampion GetGrandWinner(IList<Search> searchData);
    }
}
