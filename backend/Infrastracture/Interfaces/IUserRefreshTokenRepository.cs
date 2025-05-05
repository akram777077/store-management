using Data.Entities.Identity;
using Infrastracture.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Interfaces
{
    public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken>
    {
    }
}
