using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authentication.Queries.Requests
{
    public class CheckTokenExpiryQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
