using System.Threading.Tasks;
using System.Collections.Generic;
using SearchFight.Infrastructure.Models;

namespace SearchFight.Infrastructure.Interfaces
{
    public interface ISearchManager
    {
        
        /// Get results from search engines for the specified term.
        Task<IList<Search>> GetSearchResults(IList<string> terms);
    }
}
