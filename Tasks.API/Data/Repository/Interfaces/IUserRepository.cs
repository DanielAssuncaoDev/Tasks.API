using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces.Default;
using Tasks.API.Domain.Dto;

namespace Tasks.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryDefault<Tb_usuario, ITb_usuario>
    {
        Tb_usuario CredentialsValid(UserCredentials cred);
        void RefreshUserToken(ITb_usuario user);
        void RevokeToken(int userId);
    }
}
