using KOLT.DAL.Model;
using KOLT.DAL.Model.AuthModel;
using KOLT.DAL.Model.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KOLT.DAL.Context
{
    public class KoltDbContext : IdentityDbContext<AppUser>
    {
        public KoltDbContext(DbContextOptions<KoltDbContext> options) : base(options)
        {
        }

        

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }        
        public DbSet<OrderFood> OrderFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
