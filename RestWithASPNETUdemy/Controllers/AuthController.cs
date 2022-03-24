using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.UseCases.Interfaces;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private ILoginUseCase _loginUseCase;

        public AuthController(ILoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO userVO)
        {
            if (userVO == null) return BadRequest("Invalid client request");
            var token = _loginUseCase.ValidateCredentials(userVO);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid client request");
            var token = _loginUseCase.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest("Invalid client request");
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginUseCase.RevokeToken(username);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}
