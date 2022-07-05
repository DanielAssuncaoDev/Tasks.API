using AutoMapper;
using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Domain.Dto.Usuario;

namespace Tasks.API.Domain.Mappers
{
    public class DtoToModelMappingUser : Profile
    {
        public DtoToModelMappingUser()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<UserDto, ITb_usuario>()
                .ForMember(dest => dest.Ds_usuario, opt => opt.MapFrom(x => x.User))
                .ForMember(dest => dest.Ds_email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Hx_password, opt => opt.MapFrom(x => x.Password));

            CreateMap<Tb_usuario, UserConsult>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(x => x.Ds_usuario))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Ds_email));
        }
    }
}
