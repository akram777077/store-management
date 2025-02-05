using Core.Bases;
using MediatR;
using Core.Featurs.UnitType.Query.Response;

namespace Core.Featurs.UnitType.Query.Request;

public class GetUnitTypeByIdRequest(long id) : IRequest<Response<GetUnitTypeResponse>>
{
    public long Id { get; set; } = id;
}