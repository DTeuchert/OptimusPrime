using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Models;
using OptimusPrime.Server.Persistences;

namespace OptimusPrime.Server.Repositories
{
    public class TransformerRepository : ITransformerRepository
    {
        private readonly OptimusPrimeDbContext _dbContext;

        public TransformerRepository(OptimusPrimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _dbContext.Transformers.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> ExistsCategoryAsync(int id)
        {
            return await _dbContext.Categories.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TransformerModel>> GetAllAsync()
        {
            return (await GetQuery().ToListAsync()).Select(x => x.ToModel());
        }

        public async Task<TransformerModel> GetAsync(string guid)
        {
            return (await GetQuery().FirstOrDefaultAsync(x => x.Guid == guid))?.ToModel();
        }

        public async Task<TransformerModel> GetByNameAsync(string name)
        {
            return (await GetQuery().FirstOrDefaultAsync(x => x.Name == name))?.ToModel();
        }

        public IIncludableQueryable<Transformer, Category> GetQuery()
        {
            return _dbContext.Transformers
                .Include(t => t.Category);
        }

        public async Task<string> AddAsync(TransformerModel newTransformer, CancellationToken cancellationToken = default)
        {
            var transformer = new Transformer
            {
                Guid = new Guid().ToString(),
                Name = newTransformer.Name,
                Alliance = newTransformer.Alliance,
                CategoryId = newTransformer.Category.Id
            };
            _dbContext.Transformers.Add(transformer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return transformer.Guid;
        }

        public async Task UpdateAsync(TransformerModel updatedTransformer, CancellationToken cancellationToken = default)
        {
            var transformer = await GetQuery().SingleAsync(x => x.Guid == updatedTransformer.Id, cancellationToken);
            if (transformer is null) { return; }

            if (transformer.Name != updatedTransformer.Name) transformer.Name = updatedTransformer.Name;
            if (transformer.Alliance != updatedTransformer.Alliance) transformer.Alliance = updatedTransformer.Alliance;
            if (transformer.CategoryId != updatedTransformer.Category.Id) transformer.CategoryId = updatedTransformer.Category.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string guid, CancellationToken cancellationToken = default)
        {
            var transformer = await GetQuery().SingleAsync(x => x.Guid == guid, cancellationToken);
            if (transformer != null)
            {
                _dbContext.Transformers.Remove(transformer);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
