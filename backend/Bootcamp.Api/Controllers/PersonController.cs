using Bootcamp.Model;
using Bootcamp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Person person) { 
            var result = await _personRepository.Create(person);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _personRepository.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Route("Read")]
        public async Task<ActionResult> Read(int id)
        {
            var result = await _personRepository.Read(id);
            return Ok(result);
        }

    }
}
