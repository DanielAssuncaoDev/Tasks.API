using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository.Interfaces.Default;
using Tasks.API.Domain.Dto;

namespace Tasks.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryDefault<Tb_usuario>
    {
        Tb_usuario CredentialsValid(UserCredentials cred);
        void RefreshUserToken(Tb_usuario user);
    }
}
