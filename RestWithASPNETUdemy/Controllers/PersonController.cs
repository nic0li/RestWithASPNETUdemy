using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.HyperMedia.Filters;
using RestWithASPNETUdemy.UseCases.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize("Bearer")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonUseCase _personUseCase;

        public PersonController(ILogger<PersonController> logger, IPersonUseCase personUseCase)
        {
            _logger = logger;
            _personUseCase = personUseCase;
        }

        [HttpGet("{sortDirection}/{pageSize}/{currentPage}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(
            [FromQuery] string name,
            string sortDirection,
            int pageSize,
            int currentPage)
        {
            return Ok(_personUseCase.FindWithPagedSearch(name, sortDirection, pageSize, currentPage));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personUseCase.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpGet("findByName")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var person = _personUseCase.FindByName(firstName, lastName);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost()]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personUseCase.Create(person));
        }

        [HttpPut()]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personUseCase.Update(person));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var person = _personUseCase.Disable(id);

            return Ok(person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _personUseCase.Delete(id);

            return NoContent();
        }
    }
}