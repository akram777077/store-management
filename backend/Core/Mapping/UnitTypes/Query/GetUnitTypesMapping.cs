using System;
using Core.Featurs.UnitTypes.Query.Response;
using Data.Entities;

namespace Core.Mapping.UnitTypes;
public partial class UnitTypesProfile
{

    public void GetUnitTypesMapping()
    {
        CreateMap<UnitType, GetUnitTypeResponse>();
    }
}
