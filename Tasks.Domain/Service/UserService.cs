using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Tasks.Data.Model;
using Tasks.Data.Model.Interfaces;
using Tasks.Data.Repository.Interfaces;
using Tasks.Domain.Dto.Usuario;
using Tasks.Domain.ExceptionHandler;

namespace Tasks.Domain.Service
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

        public UserDto CredentialsValid(UserCredentials credentials)
        {
            credentials.Password = EncryptPassword(credentials.Password);
            var userCredentials = _mapper.Map<Tb_usuario>(credentials);

            return _mapper.Map<UserDto>(_userRepository.CredentialsValid(userCredentials));
        }            

        public void RefreshUserToken(UserDto user) =>
            _userRepository.RefreshUserToken(
                    _mapper.Map<Tb_usuario>(user)
                );

        public UserDto GetById(int id) =>
            _mapper.Map<UserDto>(
                    _userRepository.GetById(id)
                );

        public List<UserConsult> GetAll() =>
            _mapper.Map<List<UserConsult>>(
                _userRepository.GetAll().ToList()
            );

        public void RevokeToken(int userId) =>
            _userRepository.RevokeToken(userId);

        public UserResponseId CreateUser(User userDto)
        {
            ValidateData(userDto);

            userDto.Password = EncryptPassword(userDto.Password);
            int IdUser = _userRepository.Create(_mapper.Map<ITb_usuario>(userDto));

            if (IdUser == default)
                throw new DomainLayerException("Não foi possível cadastrar usuário.");

            return new UserResponseId(IdUser);
        }

        public UserDto GetByEmail(string email) =>
            _mapper.Map<UserDto>(
                    _userRepository.GetByEmail(email)
                );

        public UserResponseId SendActivationKey(UserEmail userEmail)
        {
            var random = new Random();
            int keyActivation = random.Next(100000, 999999);
            int userId = _userRepository.SetActivationKey(keyActivation, userEmail.Email);

            var emailService = new EmailService(userEmail.Email, keyActivation.ToString());
            emailService.SendEmail();
            return new UserResponseId(userId);
        }

        public void ActivateAccount(int userId, int key)
        {
            var user = GetById(userId);
            if (user is null)
                throw new DomainLayerException($"Não foi encontrado nenhum usuário para a ativação.");
            if (user.KeyActiveEmail != key)
                throw new DomainLayerException("Código de ativação inválido.");

            _userRepository.ActivateAccount(userId);
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

        private void ValidateData(User user)
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
            if (string.IsNullOrWhiteSpace(email)) throw new DomainLayerException("E-mail não pode estar vazio.");
            if (!email.Contains('@')) throw new DomainLayerException("E-mail inválido.");

            string domain = email.Substring(email.IndexOf('@') + 1);
            if (string.IsNullOrWhiteSpace(domain)) throw new DomainLayerException("E-mail inválido");
            if (!domain.Contains('.')) throw new DomainLayerException("E-mail inválido.");

            if (!(GetByEmail(email) is null)) throw new DomainLayerException("E-mail já cadastrado no sistema.\n Tente novamente com outro e-mail.");
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new DomainLayerException("Seu nome não pode estar vazio.");
            if (!username.Contains(' ')) throw new DomainLayerException("Insira seu nome e sobrenome.");
        }

        private void ValidatePassword(string password)
        {
            if (password.Length < 8)
                throw new DomainLayerException("A senha deve ter no minímo oito caracteres.");

            // A expressão regular verifica se exitem no mínimo três carecteres numéricos
            string regularExpression = @"(\d[\w\W]|[\w\W]\d|\d){3,}";
            if (!Regex.IsMatch(password, regularExpression))
                throw new DomainLayerException("A senha deve ter no mínimo três caracteres numéricos.");
        }

        #endregion

        #endregion

    }
}
