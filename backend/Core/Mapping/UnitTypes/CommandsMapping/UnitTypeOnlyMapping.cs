using Core.Featurs.UnitType.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.UnitTypes;


public partial class UnitTypesProfile 
{
    public void UnitTypeOnlyMapping()
    {
        CreateMap<UnitTypeNameOnlyCommand, UnitType>();
    }
}
