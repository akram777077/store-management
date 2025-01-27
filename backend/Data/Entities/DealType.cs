using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class DealType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
