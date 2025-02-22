using Core.Featurs.Users.Queries.Response;
using Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Queries.Request
{
    public class GetUsersListQuery : IRequest<PaginatedResult<GetUserResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
