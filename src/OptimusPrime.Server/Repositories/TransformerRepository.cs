using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Internal;
using OptimusPrime.Server.Internal.Transformers;
using OptimusPrime.Server.Models;
using OptimusPrime.Server.Persistences;

namespace OptimusPrime.Server.Repositories
{
    public class TransformerRepository : ITransformerRepository
    {
        private readonly OptimusPrimeDbContext _dbContext;
        private readonly TransformerQueryBuilder _queryBuilder;

        public TransformerRepository(OptimusPrimeDbContext dbContext)
        {
            _dbContext = dbContext;
            _queryBuilder = new TransformerQueryBuilder();
        }

        /// <summary>
        /// Returns a Transformer query with all includings.
        /// </summary>
        /// <returns></returns>
        private IIncludableQueryable<Transformer, Category> GetQuery()
        {
            return _dbContext.Transformers
                .Include(t => t.Category);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _dbContext.Transformers.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> ExistsCategoryAsync(int id)
        {
            return await _dbContext.Categories.AnyAsync(x => x.Id == id);
        }

        public async Task<TransformerModel> GetAsync(string guid)
        {
            return (await GetQuery().SingleAsync(x => x.Guid == guid)).ToModel();
        }

        public async Task<IList<TransformerModel>> GetAsync(Action<TransformerQueryOption> options = null)
        {
            var queryOptions = new TransformerQueryOption();
            options?.Invoke(queryOptions);

            var query = _queryBuilder.Build(GetQuery(), queryOptions);
            return (await query.ToListAsync()).Select(t => t.ToModel()).ToList();
        }

        public async Task<ResultModel<TransformerModel>> AddAsync(TransformerModel newTransformer)
        {
            if (newTransformer.Category is null)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Category need to be set."
                };
            }
            if (! await _dbContext.Categories.AnyAsync( c => c.Id == newTransformer.Category.Id))
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Invalid category id: {newTransformer.Category.Id}"
                };
            }
            if (await ExistsAsync(newTransformer.Id))
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Transformer entity with the id {newTransformer.Category.Id} already exists."
                };
            }

            var transformer = new Transformer
            {
                Guid = newTransformer.Id,
                Name = newTransformer.Name,
                Alliance = newTransformer.Alliance,
                CategoryId = newTransformer.Category.Id
            };
            _dbContext.Transformers.Add(transformer);

            try
            {
                var changedObjects = await _dbContext.SaveChangesAsync();
                return new ResultModel<TransformerModel>
                {
                    IsSuccess = changedObjects > 0,
                    Message = $"{changedObjects} objects changed.",
                    Value = transformer.ToModel()
                };
            }
            catch (Exception e)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Failed to add transformer entity in the database. {e.Message}"
                };
            }
        }

        public async Task<ResultModel<TransformerModel>> UpdateAsync(TransformerModel updatedTransformer)
        {
            var transformer = await GetQuery().SingleAsync(x => x.Guid == updatedTransformer.Id);
            if (transformer is null)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Transformer entity with the id {updatedTransformer.Id} does not exists."
                };
            }

            if (transformer.Name != updatedTransformer.Name) transformer.Name = updatedTransformer.Name;
            if (transformer.Alliance != updatedTransformer.Alliance) transformer.Alliance = updatedTransformer.Alliance;
            if (transformer.CategoryId != updatedTransformer?.Category.Id) transformer.CategoryId = updatedTransformer.Category.Id;

            try
            {
                var changedObjects = await _dbContext.SaveChangesAsync();
                return new ResultModel<TransformerModel>
                {
                    IsSuccess = changedObjects > 0,
                    Message = $"{changedObjects} objects changed.",
                    Value = transformer.ToModel()
                };
            }
            catch (Exception e)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Failed to update transformer entity in the database. {e.Message}"
                };
            }
        }

        public async Task<ResultModel<TransformerModel>> DeleteAsync(string guid)
        {
            var transformer = await GetQuery().SingleAsync(x => x.Guid == guid);
            if (transformer is null)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Transformer entity with the id {guid} does not exists."
                };
            }

            _dbContext.Transformers.Remove(transformer);

            try
            {
                var changedObjects = await _dbContext.SaveChangesAsync();
                return new ResultModel<TransformerModel>
                {
                    IsSuccess = changedObjects > 0,
                    Message = $"{changedObjects} objects changed."
                };
            }
            catch (Exception e)
            {
                return new ResultModel<TransformerModel>
                {
                    Message = $"Failed to delete transformer entity from the database. {e.Message}"
                };
            }

        }
    }
}
