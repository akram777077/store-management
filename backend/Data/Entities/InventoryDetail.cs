using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class InventoryDetail
{
    public long Id { get; set; }

    public long? InventoryId { get; set; }

    public long? ProductDetailsId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ProductDetail? ProductDetails { get; set; }
}
