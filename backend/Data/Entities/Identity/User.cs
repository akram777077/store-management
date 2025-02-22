using Data.Entities.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace Data.Entities.Identity;

public partial class User : IdentityUser, ISoftDeletable
{
    public DateTime? CreatedAt { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
}
