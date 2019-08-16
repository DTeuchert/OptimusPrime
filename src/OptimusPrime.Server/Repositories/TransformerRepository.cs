using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Persistences;
using OptimusPrime.Server.ViewModels;

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

        public async Task<IEnumerable<Transformer>> GetAllAsync()
        {
            return await GetQuery().ToListAsync();
        }

        public async Task<Transformer> GetAsync(string guid)
        {
            return await GetQuery().SingleAsync(x => x.Guid == guid);
        }

        public async Task<Transformer> GetByNameAsync(string name)
        {
            return await GetQuery().SingleAsync(x => x.Name == name);
        }

        public IQueryable<Transformer> GetQuery()
        {
            return _dbContext
                .Transformers;
        }


        public async Task AddAsync(Transformer newTransformer)
        {
            var exists = await _dbContext.Transformers.AnyAsync(i => i.Guid == newTransformer.Guid);
            if (!exists)
            {
                _dbContext.Transformers.Add(newTransformer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Transformer updatedTransformer)
        {
            var transformer = await GetAsync(updatedTransformer.Guid);
            if (transformer is null) { return; }

            if (transformer.Name != updatedTransformer.Name) transformer.Name = updatedTransformer.Name;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string guid)
        {
            var transformer = await GetAsync(guid);
            if (transformer != null)
            {
                _dbContext.Transformers.Remove(transformer);
                await _dbContext.SaveChangesAsync();
            }
        }
        public TransformerViewModel ToViewModel(Transformer transformer)
        {
            return new TransformerViewModel
            {
                Guid = transformer.Guid,
                Name = transformer.Name
            };
        }

    }
}
