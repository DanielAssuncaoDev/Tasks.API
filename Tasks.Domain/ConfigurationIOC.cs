using Autofac;
using AutoMapper;
using Tasks.Data.Repository;
using Tasks.Data.Repository.Interfaces;
using Tasks.Domain.Mappers;
using Tasks.Domain.Service;

namespace Tasks.Domain.DependencyInjection
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            // Usuário
            builder.RegisterType<UserService>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingUser());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
