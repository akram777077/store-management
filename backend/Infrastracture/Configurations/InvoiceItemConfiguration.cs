using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> entity)
    {
        entity.HasKey(e => e.Id).HasName("invoice_items_pkey");

        entity.ToTable("invoice_items");

        entity.HasIndex(e => e.ProductDetailId, "idx_invoice_items_product_detail_id");
        entity.HasIndex(e => e.SaleId, "idx_invoice_items_sale_id");
        entity.HasIndex(e => e.SaleTypeId, "idx_invoice_items_sale_type_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.DiscountPercentage)
            .HasPrecision(5, 2)
            .HasColumnName("discount_percentage");
        entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");
        entity.Property(e => e.Quantity).HasColumnName("quantity");
        entity.Property(e => e.SaleId).HasColumnName("sale_id");
        entity.Property(e => e.SaleTypeId).HasColumnName("sale_type_id");
        entity.Property(e => e.Subtotal)
            .HasPrecision(10, 2)
            .HasColumnName("subtotal");

        entity.HasOne(d => d.ProductDetail)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.ProductDetailId)
            .HasConstraintName("invoice_items_product_detail_id_fkey");

        entity.HasOne(d => d.Sale)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.SaleId)
            .HasConstraintName("invoice_items_sale_id_fkey");

        entity.HasOne(d => d.SaleType)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.SaleTypeId)
            .HasConstraintName("invoice_items_sale_type_id_fkey");
    }
}