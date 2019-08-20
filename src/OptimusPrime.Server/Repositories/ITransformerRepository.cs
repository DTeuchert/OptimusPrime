using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
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
        /// Determine whether a category exists in the database.
        /// </summary>
        /// <param name="id">Id of the category </param>
        /// <returns>Whether the category exists in the database.</returns>
        Task<bool> ExistsCategoryAsync(int id);

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
        /// Return a transformers object identified by its name.
        /// </summary>
        /// <param name="name">Name of the transformer</param>
        /// <returns>Transformer object with the name.</returns>
        Task<Transformer> GetByNameAsync(string name);

        /// <summary>
        /// Returns a Transformer query.
        /// </summary>
        /// <returns></returns>
        IIncludableQueryable<Transformer, Category> GetQuery();

        /// <summary>
        /// Add a transformer in the database.
        /// </summary>
        /// <param name="newTransformer">New transformer to store in the database</param>
        /// <returns></returns>
        Task AddAsync(Transformer newTransformer);

        /// <summary>
        /// Update a transformer object in the database.
        /// </summary>
        /// <param name="updatedTransformer">Updated transformer</param>
        /// <returns></returns>
        Task UpdateAsync(Transformer updatedTransformer);

        /// <summary>
        /// Deletes a transformer from the database.
        /// </summary>
        /// <param name="guid">Global unique identifier of the transformer</param>
        /// <returns></returns>
        Task DeleteAsync(string guid);
    }
}
