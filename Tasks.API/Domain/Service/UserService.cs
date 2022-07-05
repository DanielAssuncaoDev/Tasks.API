using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository;
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

        public Tb_usuario CredentialsValid(UserCredentials credentials) =>
            _userRepository.CredentialsValid(credentials);

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


    }
}
