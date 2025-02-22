using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateUserMapping();
            UpdateUserMapping();
            GetUserResponseMapping();
        }
    }
}
