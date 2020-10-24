using Leilao.Data.Mapping;
using Leilao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Leilao.Data.Context
{
    public class PublicSaleContext : DbContext
    {
        public DbSet<UserEntity> Users;
        public DbSet<PublicSaleEntity> PublicSales;

        public PublicSaleContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureMapConext.ConfigureMap(modelBuilder);
        }

        internal Task SingleOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
