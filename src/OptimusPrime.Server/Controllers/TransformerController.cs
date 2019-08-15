using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Repositories;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformerController : Controller
    {
        private readonly ITransformerRepository _transformerRepository;

        public TransformerController(ITransformerRepository transformerRepository)
        {
            _transformerRepository = transformerRepository;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TransformerViewModel>))]
        public async Task<IEnumerable<TransformerViewModel>> Get()
        {
            return (await _transformerRepository.GetAllAsync())
                .Select(transformer => _transformerRepository.ToViewModel(transformer));
        }

        // GET api/values/5
        [HttpGet("{guid}")]
        [ProducesResponseType(200, Type = typeof(TransformerViewModel))]
        public async Task<TransformerViewModel> Get(string guid)
        {
            return _transformerRepository.ToViewModel(await _transformerRepository.GetAsync(guid));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TransformerViewModel value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
