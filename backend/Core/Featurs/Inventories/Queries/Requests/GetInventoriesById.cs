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
    public class GetInventoriesById : IRequest<Response<GetInventoriesResponse>>
    {
        public int Id { get; set; }

        public GetInventoriesById(int id)
        {
            Id = id;
        }
    }
}
