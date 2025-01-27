using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Infrastracture.Configurations;

public class DealTypeConfiguration : IEntityTypeConfiguration<DealType>
{
    public void Configure(EntityTypeBuilder<DealType> entity)
    {
        entity.HasKey(e => e.Id).HasName("deal_types_pkey");

        entity.ToTable("deal_types");

        entity.HasIndex(e => e.Name, "deal_types_name_key").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Name).HasColumnName("name");
    }
}