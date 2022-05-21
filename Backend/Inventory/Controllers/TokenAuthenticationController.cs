using Inventory.Application.Shared.Authentications;
using Inventory.Application.Shared.Authentications.Dto;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenAuthenticationController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly IUserRepository _userRepository;
        //For every request we need to pass this in header ---> Key - authorized, and value -token
        public TokenAuthenticationController(IJwtAuth jwtAuth, IUserRepository userRepository)
        {
            this.jwtAuth = jwtAuth;
            _userRepository = userRepository;
        }
       

        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var result =  _userRepository.FindBy(x=>x.UserName== userCredential .UserName && x.Password == userCredential.Password).ToList();
            if (result.Count!=0)
            {
                var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
                return Ok(token);
            }
            //var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            //if (token == null)
            return Unauthorized();
            //return Ok(token);
        }
        [HttpGet(nameof(Get))]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
        }
    }
}
