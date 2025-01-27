using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> entity)
    {
        entity.HasKey(e => e.Id).HasName("product_details_pkey");

        entity.ToTable("product_details");

        entity.HasIndex(e => e.ProductId, "idx_product_details_product_id");
        entity.HasIndex(e => e.Barcode, "product_details_barcode_key").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Barcode).HasColumnName("barcode");
        entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
        entity.Property(e => e.ProductId).HasColumnName("product_id");
        entity.Property(e => e.Size).HasColumnName("size");
        entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
        entity.Property(e => e.Variation).HasColumnName("variation");

        entity.HasOne(d => d.Product)
            .WithMany(p => p.ProductDetails)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("product_details_product_id_fkey");
    }
}