using KOLT.DAL.Model.AuthModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.Surname)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(x => x.Telephone)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}