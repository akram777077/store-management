using Core.Bases;
using MediatR;

namespace Core.Featurs.UnitTypes.Commands.Requests;

public class UnitTypeBaseCommand : IRequest<Response<string>>
{
    public required string Name { get; set; }
}