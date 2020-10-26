using AutoMapper;
using Leilao.CrossCutting.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.CrossCutting.DependencyInjection
{
    public class ConfigureMappings
    {
        public static void Configure(IServiceCollection servicesCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntityProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            var mapper = config.CreateMapper();
            servicesCollection.AddSingleton(mapper);
        }
    }
}
