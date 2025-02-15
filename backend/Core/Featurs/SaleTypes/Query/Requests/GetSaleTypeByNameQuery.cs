using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using Core.Featurs.SaleTypes.Query.Response;
using MediatR;

namespace Core.Featurs.SaleTypes.Query.Requests
{
    public class GetSaleTypeByNameQuery(string name) : IRequest<Response<GetSaleTypesResponse>>
    {
        public string Name { get; set; } = name;
    }
}
