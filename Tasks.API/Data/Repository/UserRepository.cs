using System;
using System.Runtime.InteropServices;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository.Default;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Dto;
using System.Linq;

namespace Tasks.API.Data.Repository
{
    public class UserRepository : RepositoryDefault<Tb_usuario>, IUserRepository
    {
        public UserRepository(SqlServerContext context) 
            : base(context) { }

        /// <summary>
        /// Altera o registro especificado pelo Id
        /// </summary>
        /// <param name="model">Modelo da entidade a ser alterado</param>
        /// <param name="id">Id do registro a ser alterado</param>
        /// <returns>Entidade alterada</returns>
        public override Tb_usuario Update(Tb_usuario model, int id)
        {
            var user = GetById(id);
            if (user is null)
                throw new Exception("O usuário é inválido");

            user.Ds_usuario = model.Ds_usuario;
            user.Ds_email = model.Ds_email;
            user.Hx_password = model.Hx_password;
            user.Hx_refreshtoken = model.Hx_refreshtoken;
            user.Dh_expirationrefreshtoken = model.Dh_expirationrefreshtoken;
            user.Dh_inclusao = DateTime.Now;
            user.Tg_inativo = false;

            _context.SaveChanges();
            return user;
        }

        public Tb_usuario CredentialsValid(UserCredentials cred) =>
            _dataset.FirstOrDefault(x => x.Ds_email == cred.Email && x.Hx_password == cred.Password);

        public void RefreshUserToken(Tb_usuario user)
        {
            var userOldToken = GetById(user.Pk_id);
            userOldToken.Hx_refreshtoken = user.Hx_refreshtoken;
            userOldToken.Dh_expirationrefreshtoken = user.Dh_expirationrefreshtoken;

            _context.SaveChanges();
        }

        public void RevokeToken(int userId)
        {
            var user = GetById(userId);
            if (user is null)
                throw new Exception("O usuário é inválido");

            user.Dh_expirationrefreshtoken  = null;
            user.Hx_refreshtoken = null;
            _context.SaveChanges();
        }
    }
}
