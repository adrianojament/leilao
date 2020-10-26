using Leilao.Data.Context;
using Leilao.Data.Repositories;
using Leilao.Data.Repositories.Standard;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Interfaces.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.CrossCutting.DependencyInjection
{
    public class ConfigureRepositories
    {
        public static void ConfigureDependencies(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            serviceCollection.AddScoped<IPublicSalesRepository, PublicSalesRepository>();

            var stringConnection = ConfigurationExtensions.GetConnectionString(configuration, "Database");
            
            serviceCollection.AddDbContext<PublicSaleContext>(options =>
               options.UseNpgsql(stringConnection)
               .UseSnakeCaseNamingConvention());
        }
    }
}
