using Core.Bases;
using MediatR;
using Core.Featurs.UnitType.Query.Response;

public class GetUnitTypeByNameRequest(string name) : IRequest<Response<GetUnitTypeResponse>>
{
    public string Name { get; set; } = name;
}