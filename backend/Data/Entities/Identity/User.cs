using Data.Entities.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Entities.Identity;

public partial class User : IdentityUser, ISoftDeletable
{
    public DateTime? CreatedAt { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }

    [InverseProperty(nameof(UserRefreshToken.user))]
    public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; } = new List<UserRefreshToken>();

}
