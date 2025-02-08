using System;
using Core.Bases;
using Core.Featurs.UnitTypes.Query.Response;
using MediatR;

namespace Core.Featurs.UnitTypes.Query.Request;

public class GetUnitTypesListRequest : IRequest<Response<IEnumerable<GetUnitTypeResponse>>>
{

}
