using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class SaleTypeConfiguration : IEntityTypeConfiguration<SaleType>
{
    public void Configure(EntityTypeBuilder<SaleType> entity)
    {
        entity.HasKey(e => e.Id).HasName("sale_types_pkey");

        entity.ToTable("sale_types");

        entity.HasIndex(e => e.Name, "sale_types_name_key").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Description).HasColumnName("description");
        entity.Property(e => e.Name).HasColumnName("name");
    }
}