using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Models.Maps
{
    public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            // Keys
            this.HasKey(t => t.Id);

            // Columns
            this.Property(t => t.Id)
                .HasColumnName("id")
                .IsRequired();

            this.Property(t => t.Active)
                .HasColumnName("active")
                .IsRequired();

            this.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            this.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .IsOptional();

            this.Property(t => t.DeletedAt)
                .HasColumnName("deleted_at")
                .IsOptional();
        }
    }
}
