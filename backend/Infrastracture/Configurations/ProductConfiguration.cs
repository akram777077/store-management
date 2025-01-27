using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(e => e.Id).HasName("products_pkey");

        entity.ToTable("products");

        entity.HasIndex(e => e.BrandId, "idx_products_brand_id");
        entity.HasIndex(e => e.CategoryId, "idx_products_category_id");
        entity.HasIndex(e => e.UnitTypeId, "idx_products_unit_type_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.BrandId).HasColumnName("brand_id");
        entity.Property(e => e.CategoryId).HasColumnName("category_id");
        entity.Property(e => e.ImageUrl).HasColumnName("image_url");
        entity.Property(e => e.Name).HasColumnName("name");
        entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");

        entity.HasOne(d => d.Brand)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BrandId)
            .HasConstraintName("products_brand_id_fkey");

        entity.HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("products_category_id_fkey");

        entity.HasOne(d => d.UnitType)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.UnitTypeId)
            .HasConstraintName("products_unit_type_id_fkey");
    }
}