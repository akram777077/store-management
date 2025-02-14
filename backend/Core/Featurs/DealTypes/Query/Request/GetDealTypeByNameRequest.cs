using Core.Bases;
using Core.Featurs.DealTypes.Query.Response;
using MediatR;

namespace Core.Featurs.DealTypes.Query.Request
{
    public class GetDealTypeByNameRequest(string name) : IRequest<Response<GetDealTypeResponse>> 
    {
        public string Name { get; set; } = name;
    }
}
