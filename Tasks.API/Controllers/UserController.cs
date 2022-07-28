using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tasks.API.Domain.Dto;
using Tasks.API.Domain.Dto.Token;
using Tasks.API.Domain.Dto.Usuario;
using Tasks.API.Domain.Service;
using Tasks.API.JwtToken;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService _userService { get; set; }
        private LoginService _loginService { get; set; }
        private TokenApplicationInfo _tokenInfo { get; set; }


        public UserController(UserService userService, LoginService loginService, TokenRequestContext tokenContext)
        {
            _userService = userService;
            _loginService = loginService;
            _tokenInfo = tokenContext.TokenApplicationInfo;
        }

        #region Cadastrar-se

        [Route("Cadastrar")]
        [HttpPost]
        public ActionResult<UserResponseId> CreateUser([FromBody] UserDto user) =>
            Ok(_userService.CreateUser(user));

        #endregion

        #region Login

        [Route("Login")]
        [HttpPost]
        public ActionResult<TokenResponse> Login([FromBody] UserCredentials credentials) =>
            Ok(_loginService.GenerateToken(credentials));

        #endregion

        #region Refresh Token

        [Route("RefreshToken")]
        [HttpPut]
        public ActionResult<TokenResponse> RefreshToken([FromBody] TokenRequest tokenRequest) =>
            Ok(_loginService.RefreshToken(tokenRequest));
            
        #endregion

        #region Revoke Token

        [Route("RevokeToken")]
        [Authorize]
        [HttpPut]
        public ActionResult RevokeToken()
        {
            _loginService.RevokeToken(_tokenInfo.IdUser);
            return NoContent();
        }

        #endregion

        #region Enviar E-mail de ativação

        [Route("EnviarEmailAtivacao")]
        [HttpPut]
        public ActionResult SendEmail([FromBody] UserEmail userEmail)
        {
            _userService.SendActivationKey(userEmail);
            return NoContent();
        }

        #endregion

        #region Ativar Conta

        [Route("AtivarConta")]
        [HttpPut]
        public ActionResult ActivateAccount([FromBody] UserActivateAccount userActivateAccount)
        {
            _userService.ActivateAccount(userActivateAccount);
            return NoContent();
        }

        #endregion

    }
}
