using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class ProductDetail
{
    public long Id { get; set; }

    public string Barcode { get; set; } = null!;

    public long? ProductId { get; set; }

    public string Variation { get; set; } = null!;

    public int StockQuantity { get; set; }

    public string? Size { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public virtual ICollection<DiscountRule> DiscountRules { get; set; } = new List<DiscountRule>();

    public virtual ICollection<InventoryDetail> InventoryDetails { get; set; } = new List<InventoryDetail>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Pricing> Pricings { get; set; } = new List<Pricing>();

    public virtual Product? Product { get; set; }
}
