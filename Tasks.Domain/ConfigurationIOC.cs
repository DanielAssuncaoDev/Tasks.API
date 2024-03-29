﻿using Autofac;
using AutoMapper;
using Tasks.API.Data.Repository;
using Tasks.API.Data.Repository.Interfaces;
using Tasks.API.Domain.Mappers;
using Tasks.API.Domain.Service;

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


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingUser());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
