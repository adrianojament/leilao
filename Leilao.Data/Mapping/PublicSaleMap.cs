using Leilao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Data.Mapping
{
    public class PublicSaleMap : IEntityTypeConfiguration<PublicSaleEntity>
    {
        public void Configure(EntityTypeBuilder<PublicSaleEntity> builder)
        {
            builder.ToTable("publicsales");
            builder.UseXminAsConcurrencyToken();

            builder.HasKey(u => u.Id);            
            
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.InitalValue).IsRequired();

            builder.HasOne(u => u.ResponsibleUser).WithMany(m => m.PublicSales);
        }
    }
}