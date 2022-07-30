using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Dto;
using Tasks.API.Domain.Dto.Usuario;

namespace Tasks.API.Domain.Service
{
    public class UserService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #region Serviços do usuário

        public Tb_usuario CredentialsValid(UserCredentials credentials)
        {
            credentials.Password = EncryptPassword(credentials.Password);
            var userCredentials = _mapper.Map<Tb_usuario>(credentials);
            return _userRepository.CredentialsValid(userCredentials);
        }            

        public void RefreshUserToken(Tb_usuario user) =>
            _userRepository.RefreshUserToken(user);

        public Tb_usuario GetById(int id) =>
            _userRepository.GetById(id);

        public List<UserConsult> GetAll() =>
            _mapper.Map<List<UserConsult>>(
                _userRepository.GetAll().ToList()
            );

        public void RevokeToken(int userId) =>
            _userRepository.RevokeToken(userId);

        public UserResponseId CreateUser(UserDto userDto)
        {
            ValidateData(userDto);

            userDto.Password = EncryptPassword(userDto.Password);
            int IdUser = _userRepository.Create(_mapper.Map<ITb_usuario>(userDto));

            if (IdUser == default)
                throw new Exception("Não foi possível cadastrar usuário.");

            return new UserResponseId(IdUser);
        }

        public Tb_usuario GetByEmail(string email) =>
            _userRepository.GetByEmail(email);

        public void SendActivationKey(UserEmail userEmail)
        {
            var random = new Random();
            int keyActivation = random.Next(100000, 999999);
            _userRepository.SetActivationKey(keyActivation, userEmail.Email);

            var emailService = new EmailService(userEmail.Email, keyActivation.ToString());
            emailService.SendEmail();
        }

        public void ActivateAccount(UserActivateAccount userActivateAccount)
        {
            var user = GetByEmail(userActivateAccount.Email);
            if (user is null)
                throw new Exception($"Não foi encontrado nenhum usuário com o e-mail {userActivateAccount.Email}");

            if (user.Cd_ativacaoEmail != userActivateAccount.Key)
                throw new Exception("Código de ativação inválido.");

            _userRepository.ActivateAccount(user.Pk_id);
        }

        #endregion

        #region Métodos privados

        private string EncryptPassword(string password)
        {
            byte[] bytesPassword = Encoding.UTF8.GetBytes(password);

            var createHash = SHA256.Create();
            byte[] hashPassword = createHash.ComputeHash(bytesPassword);

            return Encoding.UTF8.GetString(hashPassword);
        }

        #region Validações de cadastro

        private void ValidateData(UserDto user)
        {
            user.Email.Trim();
            user.Password.Trim();
            user.Username.Trim();

            ValidateEmail(user.Email);
            ValidateUsername(user.Username);
            ValidatePassword(user.Password);
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("E-mail não pode estar vazio.");
            if (!email.Contains('@')) throw new Exception("E-mail inválido.");

            string domain = email.Substring(email.IndexOf('@') + 1);
            if (string.IsNullOrWhiteSpace(domain)) throw new Exception("E-mail inválido");
            if (!domain.Contains('.')) throw new Exception("E-mail inválido.");

            if (!(GetByEmail(email) is null)) throw new Exception("E-mail já cadastrado no sistema.\n Tente novamente com outro e-mail.");
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Seu nome não pode estar vazio.");
            if (!username.Contains(' ')) throw new Exception("Insira seu nome e sobrenome.");
        }

        private void ValidatePassword(string password)
        {
            if (password.Length < 8)
                throw new Exception("A senha deve ter no minímo oito caracteres.");

            // A expressão regular verifica se exitem no mínimo três carecteres numéricos
            string regularExpression = @"(\d[\w\W]|[\w\W]\d|\d){3,}";
            if (!Regex.IsMatch(password, regularExpression))
                throw new Exception("A senha deve ter no mínimo três caracteres numéricos.");
        }

        #endregion

        #endregion

    }
}
