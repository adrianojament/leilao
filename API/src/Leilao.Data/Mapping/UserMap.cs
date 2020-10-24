using Leilao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leilao.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.UseXminAsConcurrencyToken();

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        }
    }
}
