using System.Threading.Tasks;
using System.Collections.Generic;
using SearchFight.Infrastructure.Interfaces;
using SearchFight.Infrastructure.Models;
using SearchFight.Infrastructure.Repository;

namespace SearchFight.Infrastructure.Factory
{
    /// <summary>
    /// This class initialize the principal logic
    /// </summary>
    public static class SearchFightKernel
    {
        #region Attributes

        public static List<string> Reports { get; private set; }

        #endregion

        #region Services

        static ISearchManager _searchManager;
        static IChampManager _champManager;
        static IReportManager _reportManager;

        #endregion

        #region Constructors

        static SearchFightKernel()
        {
            // Initialize all our service dependencies
            _searchManager = new SearchManager();
            _champManager = new ChampManager();
            _reportManager = new ReportManager();

            // Initialize
            Reports = new List<string>();
        }

        #endregion

        #region Public Methods

        public static async Task ExecuteSearchFight(IList<string> terms)
        {
            IList<Search> searchData = await _searchManager.GetSearchResults(terms);
            IEnumerable<SearchEngineChampion> searchEngineWinners = _champManager.GetSearchEngineWinners(searchData);
            SearchEngineChampion grandChampion = _champManager.GetGrandWinner(searchData);

            Reports.AddRange(_reportManager.GetSearchResultsReport(searchData));
            Reports.AddRange(_reportManager.GetWinnersReport(searchEngineWinners));
            Reports.Add(_reportManager.GetGrandWinnerReport(grandChampion));
        }

        #endregion
    }
}
