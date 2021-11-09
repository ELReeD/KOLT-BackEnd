using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.Configuration
{
    public class OrderFoodConfiguration : IEntityTypeConfiguration<OrderFood>
    {
        public void Configure(EntityTypeBuilder<OrderFood> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasDefaultValue("NEWID()");
        }
    }
}
