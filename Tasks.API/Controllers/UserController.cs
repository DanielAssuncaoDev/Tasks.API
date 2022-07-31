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

        /// <summary>
        /// Reliza o cadastro do usuário no sistema.
        /// </summary>
        /// <param name="user">Objeto passado pelo body da requisição contendo as informações de cadastro do usuário.</param>
        /// <returns>Id do usuário cadastrado.</returns>
        [Route("SingUp")]
        [HttpPost]
        public ActionResult<UserResponseId> CreateUser([FromBody] UserDto user) =>
            Ok(_userService.CreateUser(user));

        #endregion

        #region Login

        /// <summary>
        /// Realiza o login de um usuário, retornando um Token de acesso JWT e um RefreshToken.
        /// </summary>
        /// <param name="credentials">Objeto passado pelo body da requisição contendo as credenciais do usuário.</param>
        /// <returns>Token JWT para o usuário acessar as outras rotas e um Refresh Token para o usuário poder recuperar o Token de acesso quando o mesmo estiver expirado.</returns>
        [Route("Login")]
        [HttpPost]
        public ActionResult<TokenResponse> Login([FromBody] UserCredentials credentials) =>
            Ok(_loginService.GenerateToken(credentials));

        #endregion

        #region Refresh Token

        /// <summary>
        /// Retorna um novo Token JWT. 
        /// </summary>
        /// <param name="tokenRequest">Um objeto contendo o Token de acesso e o Refresh Token do usuário.</param>
        /// <returns>Um novo token de acesso e um novo Refresh Token.</returns>
        [Route("RefreshToken")]
        [HttpPut]
        public ActionResult<TokenResponse> RefreshToken([FromBody] TokenRequest tokenRequest) =>
            Ok(_loginService.RefreshToken(tokenRequest));
            
        #endregion

        #region Revoke Token

        /// <summary>
        /// Limpa o refresh token do usuário para que o mesmo não possa fazer o Refresh Token novamente.
        /// </summary>
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

        /// <summary>
        /// Envia uma chave de ativação no e-mail do usuário para que o mesmo possa ativar sua conta.
        /// </summary>
        /// <param name="userEmail">Um objeto contendo o e-mail do usuário que se deve enviar o e-mail.</param>
        [Route("SendActivationEmail")]
        [HttpPut]
        public ActionResult SendEmail([FromBody] UserEmail userEmail) =>
            Ok(_userService.SendActivationKey(userEmail));
        

        #endregion

        #region Ativar Conta

        /// <summary>
        /// Ativa a conta do usuário.
        /// </summary>
        /// <param name="userActivateAccount">Um objeto contendo o e-mail e a chave para a ativação da conta do usuário.</param>
        [Route("ActivateAccount/{userId:int}/{key:int}")]
        [HttpPut]
        public ActionResult ActivateAccount(int userId, int key)
        {
            _userService.ActivateAccount(userId, key);
            return NoContent();
        }

        #endregion

    }
}
