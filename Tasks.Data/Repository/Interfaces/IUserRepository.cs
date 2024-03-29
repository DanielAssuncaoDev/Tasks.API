﻿using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces.Default;

namespace Tasks.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryDefault<Tb_usuario, ITb_usuario>
    {
        Tb_usuario CredentialsValid(ITb_usuario cred);
        void RefreshUserToken(ITb_usuario user);
        void RevokeToken(int userId);
        Tb_usuario GetByEmail(string email);
        void SetActivationKey(int key, string email);
        void ActivateAccount(int idUser);

    }
}
