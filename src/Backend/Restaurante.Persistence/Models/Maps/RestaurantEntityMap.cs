using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Models.Maps
{
    public class RestaurantEntityMap : BaseEntityMap<RestaurantEntity>
    {
        public RestaurantEntityMap()
        {
            // Table
            this.ToTable("Restaurants");

            // Columns
            this.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_Restaurants") { IsUnique = true }
                ));

            // Navigation
            this.HasMany(p => p.Dishes)
                .WithRequired()
                .HasForeignKey(f => f.RestaurantId);
        }
    }
}
