using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace Data.Entities.Identity;

public partial class User : IdentityUser
{
    public DateTime? CreatedAt { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
