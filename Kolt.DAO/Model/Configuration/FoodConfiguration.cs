using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasDefaultValue("NEWID()");

            builder
                  .Property(x => x.Name)
                  .HasMaxLength(30)
                  .IsRequired();

            builder
                  .Property(x => x.Ingridients)
                  .HasMaxLength(50)
                  .IsRequired();

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
               .Property(x => x.Title)
               .HasMaxLength(40)
               .IsRequired();

            builder
              .Property(x => x.CookingTime)
              .HasMaxLength(10)
              .IsRequired();
        }
    }
}
