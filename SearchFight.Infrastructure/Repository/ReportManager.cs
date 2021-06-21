using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SearchFight.Infrastructure.Interfaces;
using SearchFight.Infrastructure.Models;

namespace SearchFight.Infrastructure.Repository
{
    public class ReportManager : IReportManager
    {
        #region Constants

        public const string TOTAL_WINNER_TITLE = "Total winner: ";

        #endregion

        #region Public Methods

        public IList<string> GetSearchResultsReport(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count == 0)
                throw new ArgumentException("The specified parameter is invalid", nameof(searchData));

            return searchData.GroupBy(item => item.Term)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.SearchEngine}: {item.Results}"))}")
                .ToList();
        }

        public IList<string> GetWinnersReport(IEnumerable<SearchEngineChampion> engineWinners)
        {
            if (engineWinners == null || engineWinners.Count() == 0)
                throw new ArgumentException("The specified parameter is invalid", nameof(engineWinners));

            List<string> results = new List<string>();

            foreach (SearchEngineChampion winner in engineWinners)
            {
                StringBuilder winnerBuilder = new StringBuilder();
                winnerBuilder.Append(winner.Engine + " winner : ");
                winnerBuilder.Append(winner.Term);
                results.Add(winnerBuilder.ToString());
            }

            return results;
        }

        public string GetGrandWinnerReport(SearchEngineChampion grandChampion)
        {
            if (grandChampion == null)
                throw new ArgumentException("The specified parameter is invalid", nameof(grandChampion));

            StringBuilder grandWinnerBuilder = new StringBuilder();
            grandWinnerBuilder.Append(TOTAL_WINNER_TITLE);
            grandWinnerBuilder.Append(grandChampion.Term);
            return grandWinnerBuilder.ToString();
        }

        #endregion
    }
}
