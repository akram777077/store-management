using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class DiscountRuleConfiguration : IEntityTypeConfiguration<DiscountRule>
{
    public void Configure(EntityTypeBuilder<DiscountRule> entity)
    {
        entity.HasKey(e => e.Id).HasName("discount_rules_pkey");

        entity.ToTable("discount_rules");

        entity.HasIndex(e => e.ProductDetailId, "idx_discount_rules_product_detail_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.DiscountPrice)
            .HasPrecision(10, 2)
            .HasColumnName("discount_price");
        entity.Property(e => e.EndDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("end_date");
        entity.Property(e => e.MinQuantity).HasColumnName("min_quantity");
        entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");
        entity.Property(e => e.StartDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("start_date");

        entity.HasOne(d => d.ProductDetail)
            .WithMany(p => p.DiscountRules)
            .HasForeignKey(d => d.ProductDetailId)
            .HasConstraintName("discount_rules_product_detail_id_fkey");
    }
}