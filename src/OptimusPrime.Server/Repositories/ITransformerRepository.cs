using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Repositories
{
    public interface ITransformerRepository
    {
        /// <summary>
        /// Determine whether a transformer exists in the database.
        /// </summary>
        /// <param name="name">The transformer name to search.</param>
        /// <returns>Whether the transformer exists in the database.</returns>
        Task<bool> ExistsAsync(string name);

        /// <summary>
        /// Return all transformers stored in the database.
        /// </summary>
        /// <returns>List of all stored transformer exists in the database.</returns>
        Task<IEnumerable<Transformer>> GetAllAsync();

        /// <summary>
        /// Return a transformers object identified by the guid.
        /// </summary>
        /// <param name="guid">Global unique identifier of the transformer</param>
        /// <returns>Transformer object with the associated id.</returns>
        Task<Transformer> GetAsync(string guid);

        /// <summary>
        /// Returns a Transformer query.
        /// </summary>
        /// <returns></returns>
        IQueryable<Transformer> GetQuery();
    }
}
