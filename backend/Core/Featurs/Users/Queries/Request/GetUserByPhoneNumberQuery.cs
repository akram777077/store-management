﻿using Core.Bases;
using Core.Featurs.Users.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Queries.Request
{
    public class GetUserByPhoneNumberQuery : IRequest<Response<GetUserResponse>>
    {
        public string PhoneNumber { get; set; }
    }
}
