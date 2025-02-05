using Core.Bases;
using MediatR;

namespace Core.Featurs.UnitType.Commands.Requests;

public class UpdateUnitTypeCommand : UnitTypeNameOnlyCommand
{
    public long Id { get; set; }
}
