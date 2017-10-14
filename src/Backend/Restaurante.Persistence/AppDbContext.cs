using Restaurante.Persistence.Models;
using Restaurante.Persistence.Models.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }

        public AppDbContext() : base("RESTAURANTE")
        {
            //
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RestaurantEntityMap());
            modelBuilder.Configurations.Add(new DishEntityMap());
        }
    }
}
