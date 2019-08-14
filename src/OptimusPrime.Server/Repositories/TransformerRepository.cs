using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
    }
}
