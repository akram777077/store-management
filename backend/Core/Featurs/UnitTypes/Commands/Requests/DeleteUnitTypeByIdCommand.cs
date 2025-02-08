using Core.Bases;
using MediatR;

namespace Core.Featurs.UnitTypes.Commands.Requests;

public class DeleteUnitTypeByIdCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}