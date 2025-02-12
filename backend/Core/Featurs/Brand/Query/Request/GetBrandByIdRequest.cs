using Core.Bases;
using Core.Featurs.Brands.Query.Response;
using Core.Featurs.UnitTypes.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Brands.Query.Request
{
    public class GetBrandByIdRequest(long id) : IRequest<Response<GetBrandResponse>>
    {
        public long Id { get; set; } = id;
    }
}
