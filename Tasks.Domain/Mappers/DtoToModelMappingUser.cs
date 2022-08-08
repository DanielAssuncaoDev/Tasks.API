using AutoMapper;
using Tasks.Data.Model;
using Tasks.Data.Model.Interfaces;
using Tasks.Domain.Dto.Usuario;

namespace Tasks.Domain.Mappers
{
    public class DtoToModelMappingUser : Profile
    {
        public DtoToModelMappingUser()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<User, ITb_usuario>()
                .ConstructUsing(src => new Tb_usuario())
                .ForMember(dest => dest.Ds_usuario, opt => opt.MapFrom(x => x.Username))
                .ForMember(dest => dest.Ds_email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Hx_password, opt => opt.MapFrom(x => x.Password));

            CreateMap<Tb_usuario, UserConsult>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Ds_usuario))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Ds_email));

            CreateMap<UserCredentials, Tb_usuario>()
                .ForMember(dest => dest.Ds_email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Hx_password, opt => opt.MapFrom(x => x.Password));

            CreateMap<Tb_usuario, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Pk_id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(x => x.Ds_usuario))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Ds_usuario))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(x => x.Hx_password))
                .ForMember(dest => dest.Refreshtoken, opt => opt.MapFrom(x => x.Hx_refreshtoken))
                .ForMember(dest => dest.ExpirationRefreshToken, opt => opt.MapFrom(x => x.Dh_expiracaorefreshtoken))
                .ForMember(dest => dest.IsActiveEmail, opt => opt.MapFrom(x => x.Tg_emailAtivo))
                .ForMember(dest => dest.KeyActiveEmail, opt => opt.MapFrom(x => x.Cd_ativacaoEmail))
                .ForMember(dest => dest.DateInclusion, opt => opt.MapFrom(x => x.Dh_inclusao))
                .ForMember(dest => dest.DateChange, opt => opt.MapFrom(x => x.Dh_alteracao))
                .ForMember(dest => dest.IsInactive, opt => opt.MapFrom(x => x.Tg_inativo));

            CreateMap<UserDto, Tb_usuario>()
                .ForMember(dest => dest.Pk_id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Ds_email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Ds_usuario, opt => opt.MapFrom(x => x.User))
                .ForMember(dest => dest.Hx_password, opt => opt.MapFrom(x => x.Password))
                .ForMember(dest => dest.Hx_refreshtoken, opt => opt.MapFrom(x => x.Refreshtoken))
                .ForMember(dest => dest.Dh_expiracaorefreshtoken, opt => opt.MapFrom(x => x.ExpirationRefreshToken))
                .ForMember(dest => dest.Tg_emailAtivo, opt => opt.MapFrom(x => x.IsActiveEmail))
                .ForMember(dest => dest.Cd_ativacaoEmail, opt => opt.MapFrom(x => x.KeyActiveEmail))
                .ForMember(dest => dest.Dh_inclusao, opt => opt.MapFrom(x => x.DateInclusion))
                .ForMember(dest => dest.Dh_alteracao, opt => opt.MapFrom(x => x.DateChange))
                .ForMember(dest => dest.Tg_inativo, opt => opt.MapFrom(x => x.IsInactive));
        }
    }
}
