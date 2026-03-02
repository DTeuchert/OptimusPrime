using OptimusPrime.Domain.Models;

namespace OptimusPrime.Domain.Repositories;
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
    /// Add a transformer in the database.
    /// </summary>
    /// <param name="newTransformer">New transformer to store in the database</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    Task<string> AddAsync(Transformer newTransformer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a transformer object in the database.
    /// </summary>
    /// <param name="updatedTransformer">Updated transformer</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    Task UpdateAsync(Transformer updatedTransformer, CancellationToken cancellationToken = default);


    /// <summary>
    /// Deletes a transformer from the database.
    /// </summary>
    /// <param name="id">Global unique identifier of the transformer</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
