using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Pricing
{
    public long Id { get; set; }

    public long? ProductDetailsId { get; set; }

    public decimal PricePerUnit { get; set; }

    public decimal TaxPercentage { get; set; }

    public decimal CostPerUnit { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ProductDetail? ProductDetails { get; set; }
}
