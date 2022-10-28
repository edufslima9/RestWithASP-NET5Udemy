using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private ILoginBusiness _loginBusiness;

        public AuthController(ILogger<AuthController> logger, ILoginBusiness loginBusiness)
        {
            _logger = logger;
            _loginBusiness = loginBusiness;
        }

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null)
                return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null)
                return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(tokenVo);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpGet("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;

            var result = _loginBusiness.RevokeToken(userName);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}
