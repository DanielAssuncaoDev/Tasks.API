using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.API.JwtToken
{
    /// <summary>
    /// Classe do Token
    /// </summary>
    public class TokenService
    {
        /// <summary>
        /// Chave para possibilitar a geração do Token
        /// </summary>
        public  string SecurityKey { get; set; } = "Conde-Drakula@Tasks51282";

        /// <summary>
        /// Gera um token válido para o client poder ter acesso a outras rotas
        /// </summary>
        /// <param name="tokenConfiguration">Informações que estarão presentes no token gerado</param>
        /// <returns>Um token no formato JWT</returns>
        public string GenerateAccessToken(TokenConfiguration tokenConfiguration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecurityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim("idUser", tokenConfiguration.TokenApplicationInfo.IdUser.ToString())
                        }
                    ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Gera um RefreshToken aleatório
        /// </summary>
        /// <returns>Um RefreshToken aleatório no formato string</returns>
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        /// <summary>
        /// Recebe um AccessToken e retorna as claims do token.
        /// </summary>
        /// <param name="accessToken">Token de acesso (JWT)</param>
        /// <returns>Claims do JWT</returns>
        public ClaimsPrincipal GetPrncipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture
                )
            )
                throw new SecurityTokenException("Token inválido.");

            return principal;
        }

    }
}
