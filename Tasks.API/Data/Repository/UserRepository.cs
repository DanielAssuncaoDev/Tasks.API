using System;
using System.Runtime.InteropServices;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository.Default;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Dto;
using System.Linq;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Repository
{
    public class UserRepository : RepositoryDefault<Tb_usuario, ITb_usuario>, IUserRepository
    {
        public UserRepository(SqlServerContext context) 
            : base(context) { }

        /// <summary>
        /// Altera o registro especificado pelo Id
        /// </summary>
        /// <param name="model">Modelo da entidade a ser alterado</param>
        /// <param name="id">Id do registro a ser alterado</param>
        /// <returns>Entidade alterada</returns>
        public override Tb_usuario Update(ITb_usuario model, int id)
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

        /// <summary>
        /// Valida as informações as informações de um usuário
        /// </summary>
        /// <param name="cred">Credenciais do usuário</param>
        /// <returns>Objeto do usuário</returns>
        public Tb_usuario CredentialsValid(UserCredentials cred) =>
            _dataset.FirstOrDefault(x => x.Ds_email.Equals(cred.Email) && x.Hx_password.Equals(cred.Password));

        /// <summary>
        /// Atualiza o RefreshToken de um usuário
        /// </summary>
        /// <param name="user"></param>
        public void RefreshUserToken(ITb_usuario user)
        {
            var userOldToken = GetById(user.Pk_id);
            userOldToken.Hx_refreshtoken = user.Hx_refreshtoken;
            userOldToken.Dh_expirationrefreshtoken = user.Dh_expirationrefreshtoken;

            _context.SaveChanges();
        }

        /// <summary>
        /// Retira o RefreshToken de um usuário
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        public void RevokeToken(int userId)
        {
            var user = GetById(userId);
            if (user is null)
                throw new Exception("O usuário é inválido");

            user.Dh_expirationrefreshtoken = null;
            user.Hx_refreshtoken = null;
            _context.SaveChanges();
        }

        /// <summary>
        /// Retorna o usuário com o e-mail passado por parâmetro
        /// </summary>
        /// <param name="email">E-mail do usuário desejado</param>
        /// <returns>Usuário que contenha esse e-mail cadastrado</returns>
        public Tb_usuario GetByEmail(string email) =>
            _dataset.FirstOrDefault(x => x.Ds_email.Equals(email));

        /// <summary>
        /// Grava a chave de ativação do usuário
        /// </summary>
        /// <param name="key">Chave de ativação</param>
        /// <param name="email">E-mail do usuário em que sera gravada a chave de ativação</param>
        public void SetActivationKey(int key, string email)
        {
            var user = GetByEmail(email);
            if (user is null)
                throw new Exception("Não foi encontrado nenhum usuário com o e-mail enviado");

            user.Cd_ativacaoEmail = key;
            _context.SaveChanges();
        }

    }
}
