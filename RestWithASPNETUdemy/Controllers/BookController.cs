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
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookUseCase _bookUseCase;

        public BookController(ILogger<BookController> logger, IBookUseCase bookUseCase)
        {
            _logger = logger;
            _bookUseCase = bookUseCase;
        }

        [HttpGet()]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookUseCase.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookUseCase.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost()]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookUseCase.Create(book));
        }

        [HttpPut()]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookUseCase.Update(book));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _bookUseCase.Delete(id);

            return NoContent();
        }
    }
}