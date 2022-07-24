using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Domain.Dto.Usuario
{
    public class UserResponseId
    {
        public UserResponseId(int idUser)
        {
            this.idUser = idUser;
        }

        public int idUser { get; set; }
    }
}
