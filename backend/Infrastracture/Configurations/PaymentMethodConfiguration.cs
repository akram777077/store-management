using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> entity)
    {
        entity.HasKey(e => e.Id).HasName("payment_methods_pkey");

        entity.ToTable("payment_methods");

        entity.HasIndex(e => e.MethodName, "payment_methods_method_name_key").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.MethodName).HasColumnName("method_name");
    }
}