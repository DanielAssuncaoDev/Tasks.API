using System;
using Tasks.API.Domain.Dto;
using Tasks.API.Domain.Dto.Token;
using Tasks.API.Domain.Service;
using Tasks.API.JwtToken;

namespace Tasks.API.JwtToken
{
    public class LoginService
    {
        public UserService _userService { get; set; }
        public TokenService _tokenService { get; set; }

        public LoginService(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Recebe as credenciais do usuáio, valida-as e retorna um token de acesso JWT
        /// </summary>
        /// <param name="credentials">Objeto com as credenciais do usuário</param>
        /// <returns>Token de acesso JWT</returns>
        public TokenResponse GenerateToken(UserCredentials credentials)
        {
            var user = _userService.CredentialsValid(credentials);
            if (user is null)
                throw new Exception("Credenciais inválidas.");
            if (!user.Tg_emailAtivo)
                throw new Exception("Conta não está ativada, ative sua conta para fazer o login.");

            var accessToken = _tokenService.GenerateAccessToken(
                    new TokenConfiguration()
                    {
                        TokenApplicationInfo = new TokenApplicationInfo() { IdUser = user.Pk_id }
                    }
                );
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.Hx_refreshtoken = refreshToken;
            user.Dh_expirationrefreshtoken = DateTime.UtcNow.AddDays(1);
            _userService.RefreshUserToken(user);

            return new TokenResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Valida o RefreshToken recebido, atualiza o RefreshToken do usuário e retorna um novo Token JWT 
        /// </summary>
        /// <param name="token">Objeto com o AccessToken e RefreshToken</param>
        /// <returns>Um novo AccessToken para o usuário</returns>
        public TokenResponse RefreshToken(TokenRequest token)
        {
            var refreshToken = token.RefreshToken;
            var tokenInfo = _tokenService.GetClaimsFromExpiredToken(token.AccessToken);        
            
            var user = _userService.GetById(tokenInfo.IdUser);
            if (user is null)
                return null;

            if (user.Hx_refreshtoken != refreshToken)
                throw new Exception("RefreshToken inválido.");
            if (user.Dh_expirationrefreshtoken < DateTime.Now)
                throw new Exception("RefreshToken inspirado, logue-se novamente.");
            
            var accessToken = _tokenService.GenerateAccessToken(
                new TokenConfiguration()
                {
                    TokenApplicationInfo = new TokenApplicationInfo() { IdUser = user.Pk_id }
                }
            );
            refreshToken = _tokenService.GenerateRefreshToken();

            user.Hx_refreshtoken = refreshToken;
            user.Dh_expirationrefreshtoken = DateTime.UtcNow.AddDays(1);
            _userService.RefreshUserToken(user);

            return new TokenResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Retira o refreshToken de um usuário para que ele não seja mais usado
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        public void RevokeToken(int? userId)
        {
            if (userId is null)
                throw new Exception("Token inválido.");

            _userService.RevokeToken(userId.Value);
        }
            

    }
}
