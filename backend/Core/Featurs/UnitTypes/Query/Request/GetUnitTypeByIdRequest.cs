using Core.Bases;
using MediatR;
using Core.Featurs.UnitTypes.Query.Response;

namespace Core.Featurs.UnitTypes.Query.Request;

public class GetUnitTypeByIdRequest(long id) : IRequest<Response<GetUnitTypeResponse>>
{
    public long Id { get; set; } = id;
}