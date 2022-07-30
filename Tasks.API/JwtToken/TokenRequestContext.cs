using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tasks.API.JwtToken
{
    /// <summary>
    /// Pega as informaçoes das Claims de um Token JWT pela chamada HTTP
    /// </summary>
    public class TokenRequestContext
    {
        /// <summary>
        /// Informações armazenadas nas claims o Token JWT
        /// </summary>
        public TokenApplicationInfo TokenApplicationInfo { get; set; }
       
        public TokenRequestContext(IHttpContextAccessor httpAccessor)
        {
            var tokenService = new TokenService();

            if (!(httpAccessor is null))
            {
                if (httpAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
                    TokenApplicationInfo = tokenService.GetDataClaims(identity);
            }
        }


    }
}
