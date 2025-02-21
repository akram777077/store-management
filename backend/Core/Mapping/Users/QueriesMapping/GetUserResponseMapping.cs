﻿using Core.Featurs.Users.Queries.Response;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Users
{
    public partial class UserProfile
    {
        private void GetUserResponseMapping()
        {
            CreateMap<User, GetUserResponse>();
        }
    }
}
