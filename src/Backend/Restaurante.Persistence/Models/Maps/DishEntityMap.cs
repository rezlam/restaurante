using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Models.Maps
{
    public class DishEntityMap : BaseEntityMap<DishEntity>
    {
        public DishEntityMap()
        {
            // Table
            this.ToTable("Dishes");

            // Columns
            this.Property(p => p.RestaurantId)
                .HasColumnName("restaurant_id")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_Dishes") { IsUnique = true, Order = 1 }
                ));

            this.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_Dishes") { IsUnique = true, Order = 2 }
                ));

            this.Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .IsRequired();

            this.HasRequired(p => p.Restaurant);
        }
    }
}
