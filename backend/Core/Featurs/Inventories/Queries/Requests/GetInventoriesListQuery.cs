using Core.Bases;
using Core.Featurs.Inventories.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Queries.Requests
{
    public class GetInventoriesListQuery : IRequest<Response<IEnumerable<GetInventoriesResponse>>>
    {
    }
}
