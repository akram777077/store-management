using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class InventoryDetailConfiguration : IEntityTypeConfiguration<InventoryDetail>
{
    public void Configure(EntityTypeBuilder<InventoryDetail> entity)
    {
        entity.HasKey(e => e.Id).HasName("inventory_details_pkey");

        entity.ToTable("inventory_details");

        entity.HasIndex(e => e.InventoryId, "idx_inventory_details_inventory_id");
        entity.HasIndex(e => e.ProductDetailsId, "idx_inventory_details_product_details_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Date)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("date");
        entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
        entity.Property(e => e.ProductDetailsId).HasColumnName("product_details_id");

        entity.HasOne(d => d.Inventory)
            .WithMany(p => p.InventoryDetails)
            .HasForeignKey(d => d.InventoryId)
            .HasConstraintName("inventory_details_inventory_id_fkey");

        entity.HasOne(d => d.ProductDetails)
            .WithMany(p => p.InventoryDetails)
            .HasForeignKey(d => d.ProductDetailsId)
            .HasConstraintName("inventory_details_product_details_id_fkey");
    }
}