using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Dto;

namespace Tasks.API.Domain.Service
{
    public class UserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Tb_usuario CredentialsValid(UserCredentials credentials) =>
            _userRepository.CredentialsValid(credentials);

        public void RefreshUserToken(Tb_usuario user) =>
            _userRepository.RefreshUserToken(user);

        public Tb_usuario GetById(int id) =>
            _userRepository.GetById(id);
        
        public List<Tb_usuario> GetAll() =>
            _userRepository.GetAll().ToList();

        

    }
}
