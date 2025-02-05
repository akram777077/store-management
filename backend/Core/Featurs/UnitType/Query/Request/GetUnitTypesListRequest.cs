using System;
using Core.Bases;
using Core.Featurs.UnitType.Query.Response;
using MediatR;

namespace Core.Featurs.UnitType.Query.Request;

public class GetUnitTypesListRequest : IRequest<Response<IEnumerable<GetUnitTypesResponse>>>
{

}
