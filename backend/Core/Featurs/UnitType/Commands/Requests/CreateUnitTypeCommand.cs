using Core.Bases;
using MediatR;

namespace Core.Featurs.UnitType.Commands.Requests;

public class CreateUnitTypeCommand : IRequest<Response<string>>
{
    public required string Name { get; set; } 
}