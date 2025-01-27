using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> entity)
    {
        entity.HasKey(e => e.Id).HasName("inventories_pkey");

        entity.ToTable("inventories");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.LastUpdated)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("last_updated");
        entity.Property(e => e.Location).HasColumnName("location");
        entity.Property(e => e.Quantity).HasColumnName("quantity");
    }
}