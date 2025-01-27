using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
{
    public void Configure(EntityTypeBuilder<Pricing> entity)
    {
        entity.HasKey(e => e.Id).HasName("pricing_pkey");

        entity.ToTable("pricing");

        entity.HasIndex(e => e.ProductDetailsId, "idx_pricing_product_details_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CostPerUnit)
            .HasPrecision(10, 2)
            .HasColumnName("cost_per_unit");
        entity.Property(e => e.EndDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("end_date");
        entity.Property(e => e.PricePerUnit)
            .HasPrecision(10, 2)
            .HasColumnName("price_per_unit");
        entity.Property(e => e.ProductDetailsId).HasColumnName("product_details_id");
        entity.Property(e => e.StartDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("start_date");
        entity.Property(e => e.TaxPercentage)
            .HasPrecision(5, 2)
            .HasColumnName("tax_percentage");

        entity.HasOne(d => d.ProductDetails)
            .WithMany(p => p.Pricings)
            .HasForeignKey(d => d.ProductDetailsId)
            .HasConstraintName("pricing_product_details_id_fkey");
    }
}