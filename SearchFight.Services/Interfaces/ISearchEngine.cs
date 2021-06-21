using System.Threading.Tasks;

namespace SearchFight.Services.Interfaces
{
    /// <summary>
    /// Interface to be implemented with many engines
    /// </summary>
    public interface ISearchEngine
    {
        /// Name Search Engine
        string Name { get; }

        /// Get total result count from implemented search engine.
        Task<long> GetTotalResultsAsync(string query);
    }
}
