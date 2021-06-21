using System.Collections.Generic;
using SearchFight.Infrastructure.Models;

namespace SearchFight.Infrastructure.Interfaces
{
    public interface IReportManager
    {
        /// Generate the report with the search results by term.
        IList<string> GetSearchResultsReport(IList<Search> searchData);

        /// Generate the report with the search engine winners.
        IList<string> GetWinnersReport(IEnumerable<SearchEngineChampion> engineWinners);

        /// Generate the report with the grand winner.
        string GetGrandWinnerReport(SearchEngineChampion grandChampion);
    }
}
