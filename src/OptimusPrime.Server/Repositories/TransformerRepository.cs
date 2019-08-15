using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;
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

        public async Task<IEnumerable<Transformer>> GetAllAsync()
        {
            return await GetQuery().ToListAsync();
        }

        public async Task<Transformer> GetAsync(string guid)
        {
            return await GetQuery().SingleAsync(x => x.Guid == guid);
        }

        public IQueryable<Transformer> GetQuery()
        {
            return _dbContext
                .Transformers;
        }

    }
}
