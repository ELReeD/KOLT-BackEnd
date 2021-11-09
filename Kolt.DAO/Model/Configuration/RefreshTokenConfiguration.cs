using KOLT.DAL.Model.AuthModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder
                .HasKey(x => x.Token);

            builder
                .Property(x => x.Token)
                .IsRequired();

        }
    }
}
