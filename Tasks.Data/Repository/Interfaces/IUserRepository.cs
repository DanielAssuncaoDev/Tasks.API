using Tasks.Data.Model;
using Tasks.Data.Model.Interfaces;
using Tasks.Data.Repository.Interfaces.Default;

namespace Tasks.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryDefault<Tb_usuario, ITb_usuario>
    {
        Tb_usuario CredentialsValid(ITb_usuario cred);
        void RefreshUserToken(ITb_usuario user);
        void RevokeToken(int userId);
        Tb_usuario GetByEmail(string email);
        int SetActivationKey(int key, string email);
        void ActivateAccount(int idUser);

    }
}
