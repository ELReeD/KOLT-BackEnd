using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.Configuration
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasDefaultValue("NEWID()");

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(x => x.Adress)
                .IsRequired()
                .HasMaxLength(50);

            builder
              .Property(x => x.Radius)
              .IsRequired()
              .HasMaxLength(50);

            builder
               .Property(x => x.Number)               
               .IsRequired();

            builder
               .Property(x => x.Latitude)
               .IsRequired();

            builder
              .Property(x => x.Longitude)
              .IsRequired();
        }
    }
}
