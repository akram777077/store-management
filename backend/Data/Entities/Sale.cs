using System;
using System.Collections.Generic;
using Data.Entities.Identity;

namespace Data.Entities;

public partial class Sale
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public decimal TotalPrice { get; set; }

    public required string MarketName { get; set; }

    public long DealTypeId { get; set; }

    public required string UserId { get; set; } required

    public long PaymentMethodId { get; set; }

    public virtual DealType? DealType { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual User? User { get; set; }
}
