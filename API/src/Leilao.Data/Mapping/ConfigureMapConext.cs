using Leilao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Data.Mapping
{
    public class ConfigureMapConext
    {
        public static void ConfigureMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<PublicSaleEntity>(new PublicSaleMap().Configure);
        }
    }
}
