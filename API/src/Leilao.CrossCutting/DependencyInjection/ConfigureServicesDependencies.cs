using Leilao.Domain.Interfaces.Services;
using Leilao.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.CrossCutting.DependencyInjection
{
    public class ConfigureServicesDependencies
    {
        public static void Configure(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IUserService, UserService>();
            servicesCollection.AddTransient<IPublicSaleService, PublicSaleService>();
        }
    }
}
