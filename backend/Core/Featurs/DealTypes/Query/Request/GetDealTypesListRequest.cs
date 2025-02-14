using Core.Bases;
using Core.Featurs.DealTypes.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.DealTypes.Query.Request
{
    public class GetDealTypesListRequest : IRequest<Response<IEnumerable<GetDealTypeResponse>>>
    {
    }
}
