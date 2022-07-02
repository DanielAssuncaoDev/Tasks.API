using Autofac;
using Tasks.API.Data.Repository;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Service;
using Tasks.API.JwtToken;

namespace Tasks.API.DependencyInjection
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            // Usuário
            builder.RegisterType<UserService>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();

            // Login
            builder.RegisterType<LoginService>();
            builder.RegisterType<TokenService>();
            
        }
    }
}
