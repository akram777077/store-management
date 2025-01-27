using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? CategoryId { get; set; }

    public long? UnitTypeId { get; set; }

    public string? ImageUrl { get; set; }

    public long? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual UnitType? UnitType { get; set; }
}
