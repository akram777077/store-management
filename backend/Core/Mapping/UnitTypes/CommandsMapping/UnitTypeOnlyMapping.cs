using Core.Featurs.UnitTypes.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.UnitTypes;


public partial class UnitTypeProfile 
{
    public void UnitTypeOnlyMapping()
    {
        CreateMap<UnitTypeBaseCommand, UnitType>();
    }
}
