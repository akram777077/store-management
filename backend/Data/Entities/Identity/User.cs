using System;
using System.Collections.Generic;

namespace Data.Entities.Identity;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
