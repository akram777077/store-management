using Core.Featurs.UnitTypes.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.UnitTypes;


public partial class UnitTypesProfile 
{
    public void UnitTypeOnlyMapping()
    {
        CreateMap<UnitTypeBaseCommand, UnitType>();
    }
}
