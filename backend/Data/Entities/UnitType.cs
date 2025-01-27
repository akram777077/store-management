using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class UnitType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
