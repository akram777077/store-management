using Data.Entities.Identity;
using Infrastracture.Base;
using Infrastracture.Data;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        #region Fields
        private readonly DbSet<UserRefreshToken> _userRefreshToken;
        #endregion
        #region Constructor
        public UserRefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {
            _userRefreshToken = dbContext.UserRefreshTokens;
        }
        #endregion
    }
}
