using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Internal.Transformers;
using OptimusPrime.Server.Models;

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
        /// Return a transformers object identified by the guid.
        /// </summary>
        /// <param name="guid">Global unique identifier of the transformer</param>
        /// <returns>Transformer object with the associated id.</returns>
        Task<TransformerModel> GetAsync(string guid);

        /// <summary>
        /// Returns a list of transformer objects filtered by<see cref="OptimusPrime.Server.Internal.Transformers.TransformerQueryOption">.
        /// When no filter options are set, the function will return all objects.
        /// </summary>
        /// <param name="options">Filter options</param>
        /// <returns>List of all stored transformers matching the filter options, exists in the database.</returns>
        Task<IList<TransformerModel>> GetAsync(Action<TransformerQueryOption> options = null);

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
        Task AddAsync(TransformerModel newTransformer);

        /// <summary>
        /// Update a transformer object in the database.
        /// </summary>
        /// <param name="updatedTransformer">Updated transformer</param>
        /// <returns></returns>
        Task UpdateAsync(TransformerModel updatedTransformer);

        /// <summary>
        /// Deletes a transformer from the database.
        /// </summary>
        /// <param name="guid">Global unique identifier of the transformer</param>
        /// <returns></returns>
        Task DeleteAsync(string guid);
    }
}
