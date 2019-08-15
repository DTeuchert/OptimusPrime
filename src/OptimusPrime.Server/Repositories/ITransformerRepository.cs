using System.Threading.Tasks;

namespace OptimusPrime.Server.Repositories
{
    interface ITransformerRepository
    {
        /// <summary>
        /// Determine whether a transformer exists in the database.
        /// </summary>
        /// <param name="name">The transformer name to search.</param>
        /// <returns>Whether the transformer exists in the database.</returns>
        Task<bool> ExistsAsync(string name);
    }
}
