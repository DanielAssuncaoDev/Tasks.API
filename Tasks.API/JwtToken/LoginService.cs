using System;
using Tasks.API.ExceptionsHandler;
using Tasks.Domain.Dto.Token;
using Tasks.Domain.Dto.Usuario;
using Tasks.Domain.Service;

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
        public Token GenerateToken(UserCredentials credentials)
        {
            var user = _userService.CredentialsValid(credentials); 
            if (user is null)
                throw new ApiLayerException("Credenciais inválidas.");
            if (!user.IsActiveEmail)
                throw new ApiLayerException("Sua conta não está ativada, ative sua conta para fazer o login.");

            var accessToken = _tokenService.GenerateAccessToken(
                    new TokenConfiguration()
                    {
                        TokenApplicationInfo = new TokenApplicationInfo() { IdUser = user.Id }
                    }
                );
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.Refreshtoken = refreshToken;
            user.ExpirationRefreshToken = DateTime.UtcNow.AddDays(1);
            _userService.RefreshUserToken(user);

            return new Token()
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
        public Token RefreshToken(Token token)
        {
            var refreshToken = token.RefreshToken;
            var tokenInfo = _tokenService.GetClaimsFromExpiredToken(token.AccessToken);        
            
            var user = _userService.GetById(tokenInfo.IdUser);
            if (user is null)
                return null;

            if (user.Refreshtoken != refreshToken)
                throw new ApiLayerException("Não foi possível realizar o login automático, logue-se novamente.");
            if (user.ExpirationRefreshToken < DateTime.Now)
                throw new ApiLayerException("Login inspirado, logue-se novamente.");
            
            var accessToken = _tokenService.GenerateAccessToken(
                new TokenConfiguration()
                {
                    TokenApplicationInfo = new TokenApplicationInfo() { IdUser = user.Id }
                }
            );
            refreshToken = _tokenService.GenerateRefreshToken();

            user.Refreshtoken = refreshToken;
            user.ExpirationRefreshToken = DateTime.UtcNow.AddDays(1);
            _userService.RefreshUserToken(user);

            return new Token()
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
            if (userId is not null)
                _userService.RevokeToken(userId.Value);
        }
            

    }
}
