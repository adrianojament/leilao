using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<PublicSaleContext>
    {
        public PublicSaleContext CreateDbContext(string[] args)
        {
            var basePath = AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("jsconfig.json")
                .AddEnvironmentVariables();

            var config = builder.Build();

            var stringConnection = config.GetConnectionString("Database");

            var options = new DbContextOptionsBuilder<PublicSaleContext>()
               .UseNpgsql(stringConnection)
               .UseSnakeCaseNamingConvention()
               .Options;

            return new PublicSaleContext(options);
        }
    }
}
