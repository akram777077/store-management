using Core.Featurs.UnitTypes.Query.Response;
using Data.Entities;

namespace Core.Mapping.UnitTypes;


public partial class UnitTypeProfile
{

    public void GetUnitTypeMapping()
    {
        CreateMap<UnitType, GetUnitTypeResponse>();
    }
}