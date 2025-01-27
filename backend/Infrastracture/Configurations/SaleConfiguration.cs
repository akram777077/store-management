using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> entity)
    {
        entity.HasKey(e => e.Id).HasName("sales_pkey");

        entity.ToTable("sales");

        entity.HasIndex(e => e.DealTypeId, "idx_sales_deal_type_id");
        entity.HasIndex(e => e.PaymentMethodId, "idx_sales_payment_method_id");
        entity.HasIndex(e => e.UserId, "idx_sales_user_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Date)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("date");
        entity.Property(e => e.DealTypeId).HasColumnName("deal_type_id");
        entity.Property(e => e.MarketName).HasColumnName("market_name");
        entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
        entity.Property(e => e.TotalPrice)
            .HasPrecision(10, 2)
            .HasColumnName("total_price");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.DealType)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.DealTypeId)
            .HasConstraintName("sales_deal_type_id_fkey");

        entity.HasOne(d => d.PaymentMethod)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.PaymentMethodId)
            .HasConstraintName("sales_payment_method_id_fkey");

        entity.HasOne(d => d.User)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("sales_user_id_fkey");
    }
}