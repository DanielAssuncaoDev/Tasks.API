using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.JwtToken
{
    /// <summary>
    /// Informações geradas no JWT que podem estar disponíveis para toda a aplicação
    /// </summary>
    public class TokenApplicationInfo
    {
        public int IdUser { get; set; }
    }
}
