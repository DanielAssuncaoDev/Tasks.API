using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tasks.API.Domain.Dto;
using Tasks.API.Domain.Dto.Token;
using Tasks.API.Domain.Dto.Usuario;
using Tasks.API.Domain.Service;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService _userService { get; set; }
        private LoginService _loginService { get; set; }

        public UserController(UserService userService, LoginService loginService)
        {
            _userService = userService;
            _loginService = loginService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<UserConsult>> ObterUsuarios() =>
            Ok(_userService.GetAll());

        [Route("Login")]
        [HttpPost]
        public ActionResult<TokenResponse> Login([FromBody] UserCredentials credentials) =>
            Ok(_loginService.GenerateToken(credentials));

        [Route("RefreshToken")]
        [HttpPut]
        public ActionResult<TokenResponse> RefreshToken([FromBody] TokenRequest tokenRequest) =>
            Ok(_loginService.RefreshToken(tokenRequest));

        [Route("RevokeToken")]
        [Authorize]
        [HttpPut]
        public ActionResult RevokeToken()
        {
            int? userId = int.Parse(User.FindFirst("IdUser").Value);
            _loginService.RevokeToken(userId);

            return NoContent();
        }
            


    }
}
