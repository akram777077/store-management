using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class PaymentMethod
{
    public long Id { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
