using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OptimusPrime.Domain.Models;
using OptimusPrime.Domain.Repositories;
using OptimusPrime.Infrastructure.Persistence;

namespace OptimusPrime.Infrastructure.Repositories
{
    public class TransformerRepository(OptimusPrimeDbContext dbContext) : ITransformerRepository
    {
        public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
        {
            return await dbContext.Transformers.AnyAsync(x => x.Name == name, cancellationToken);
        }

        public async Task<bool> ExistsCategoryAsync(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Categories.AnyAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Transformer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return (await GetQuery().ToListAsync(cancellationToken)).Select(x => x.ToModel());
        }

        public async Task<Transformer> GetAsync(string guid, CancellationToken cancellationToken)
        {
            return (await GetQuery().FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken))?.ToModel();
        }

        public async Task<Transformer> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return (await GetQuery().FirstOrDefaultAsync(x => x.Name == name, cancellationToken))?.ToModel();
        }

        private IIncludableQueryable<Persistence.Entities.Transformer> GetQuery()
        {
            return dbContext.Transformers
                .Include(t => t.Category);
        }

        public async Task<Guid> AddAsync(Transformer newTransformer, CancellationToken cancellationToken = default)
        {
            var transformer = new Infrastructure.Persistence.Entities.Transformer
            {
                Id = Guid.NewGuid(),
                Name = newTransformer.Name,
                Alliance = newTransformer.Alliance,
                CategoryId = newTransformer.Category.Id
            };
            dbContext.Transformers.Add(transformer);
            await dbContext.SaveChangesAsync(cancellationToken);

            return transformer.Id;
        }

        public async Task UpdateAsync(Transformer updatedTransformer, CancellationToken cancellationToken = default)
        {
            var transformer = await GetQuery().FirstOrDefaultAsync(x => x.Id == updatedTransformer.Id, cancellationToken);
            if (transformer is null) { return; }

            if (transformer.Name != updatedTransformer.Name) transformer.Name = updatedTransformer.Name;
            if (transformer.Alliance != updatedTransformer.Alliance) transformer.Alliance = updatedTransformer.Alliance;
            if (transformer.CategoryId != updatedTransformer.Category.Id) transformer.CategoryId = updatedTransformer.Category.Id;

            await dbContext.SaveChangesAsync(cancellationToken);
        }

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
}
