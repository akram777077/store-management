using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class DiscountRule
{
    public long Id { get; set; }

    public long? ProductDetailId { get; set; }

    public int? MinQuantity { get; set; }

    public decimal? DiscountPrice { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ProductDetail? ProductDetail { get; set; }
}
