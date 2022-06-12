using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Domain.Dto;
using Tasks.API.JwtToken;

namespace Tasks.API.Domain.Service
{
    public class LoginService
    {
        public UserService _userService { get; set; }
        public TokenService _tokenService { get; set; }


        public TokenResponse ValidateCredentials(UserCredentials credentials)
        {
            var user = _userService.CredentialsValid(credentials);
            if (user is null)
                throw new Exception("Credenciais inválidas.");

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

    }
}
