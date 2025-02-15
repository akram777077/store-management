using Core.Bases;
using Core.Featurs.SaleTypes.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.SaleTypes.Query.Requests
{
    public class GetSaleTypeByIdQuery(long id) : IRequest<Response<GetSaleTypesResponse>>
    {
        public long Id { get; set; } = id;
    }
}
