using Microsoft.EntityFrameworkCore;
using OptimusPrime.Domain.Repositories;
using OptimusPrime.Infrastructure.Persistence;
using OptimusPrime.Infrastructure.Persistence.Entities;
using Transformer = OptimusPrime.Domain.Models.Transformer;

namespace OptimusPrime.Infrastructure.Repositories;
public class TransformerRepository(OptimusPrimeDbContext dbContext) : ITransformerRepository
{
    
    private IQueryable<Persistence.Entities.Transformer> GetQuery()
    {
        return dbContext.Transformers
            .Include(t => t.Category);
    }
    
    /// <summary>
    /// Determine whether a transformer exists in the database.
    /// </summary>
    /// <param name="name">The transformer name to search.</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns>Whether the transformer exists in the database.</returns>
    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await GetQuery().AnyAsync(x => x.Name == name, cancellationToken);
    }
    
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await GetQuery().AnyAsync(x => x.Id == id, cancellationToken);
    }
    
    /// <summary>
    /// Return all transformers stored in the database.
    /// </summary>
    /// <param name="cancellationToken">The transformer name to search.</param>
    /// <returns>List of all stored transformer exists in the database.</returns>
    public async Task<IEnumerable<Transformer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return (await GetQuery().ToListAsync(cancellationToken)).Select(x => x.ToModel());
    }

    /// <summary>
    /// Return a transformers object identified by the guid.
    /// </summary>
    /// <param name="id">Global unique identifier of the transformer</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns>Transformer object with the associated id.</returns>
    public async Task<Transformer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetQuery().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity is null
            ? throw new KeyNotFoundException()
            : entity.ToModel();
    }
    
    /// <summary>
    /// Add a transformer in the database.
    /// </summary>
    /// <param name="model">New transformer to store in the database</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    public async Task<Guid> AddAsync(Transformer model, CancellationToken cancellationToken = default)
    {
        var transformer = new Infrastructure.Persistence.Entities.Transformer
        {
            Id = model.Id,
            Name = model.Name,
            AllianceId = model.Alliance.Id,
            CategoryId = model.Category.Id
        };
        dbContext.Transformers.Add(transformer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return transformer.Id;
    }

    /// <summary>
    /// Update a transformer object in the database.
    /// </summary>
    /// <param name="model">Updated transformer</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    public async Task UpdateAsync(Transformer model, CancellationToken cancellationToken = default)
    {
        var transformer = await dbContext.Transformers
            .Include(t => t.Category).FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);
        if (transformer is null) { return; }
        if (transformer.Name != model.Name) transformer.Name = model.Name;
        if (transformer.AllianceId != model.Alliance.Id) transformer.AllianceId = model.Alliance.Id;
        if (transformer.CategoryId != model.Category.Id) transformer.CategoryId = model.Category.Id;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Deletes a transformer from the database.
    /// </summary>
    /// <param name="id">Global unique identifier of the transformer</param>
    /// <param name="cancellationToken">Cancel token </param>
    /// <returns></returns>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transformer = await GetQuery().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (transformer != null)
        {
            dbContext.Transformers.Remove(transformer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
