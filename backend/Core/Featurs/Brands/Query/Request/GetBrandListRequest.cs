using Core.Bases;
using Core.Featurs.Brands.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Brands.Query.Request
{
    public class GetBrandListRequest : IRequest<Response<IEnumerable<GetBrandResponse>>>
    {
    }
}
