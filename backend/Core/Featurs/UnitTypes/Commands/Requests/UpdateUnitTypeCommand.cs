using Core.Bases;
using MediatR;

namespace Core.Featurs.UnitTypes.Commands.Requests;

public class UpdateUnitTypeCommand : UnitTypeBaseCommand
{
    public long Id { get; set; }
}
