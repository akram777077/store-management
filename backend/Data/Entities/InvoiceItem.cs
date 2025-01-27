using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class InvoiceItem
{
    public long Id { get; set; }

    public long? ProductDetailId { get; set; }

    public long? SaleId { get; set; }

    public int? Quantity { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public decimal? Subtotal { get; set; }

    public long? SaleTypeId { get; set; }

    public virtual ProductDetail? ProductDetail { get; set; }

    public virtual Sale? Sale { get; set; }

    public virtual SaleType? SaleType { get; set; }
}
