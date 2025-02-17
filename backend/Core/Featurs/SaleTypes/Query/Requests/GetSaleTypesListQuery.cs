using Core.Bases;
using Core.Featurs.SaleTypes.Query.Response;
using MediatR;

namespace Core.Featurs.SaleTypes.Query.Requests
{
    public class GetSaleTypesListQuery : IRequest<Response<IEnumerable<GetSaleTypesResponse>>>
    {
    }
}
