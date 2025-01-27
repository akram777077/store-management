using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Inventory
{
    public long Id { get; set; }

    public string Location { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual ICollection<InventoryDetail> InventoryDetails { get; set; } = new List<InventoryDetail>();
}
