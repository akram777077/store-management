using System;
using AutoMapper;

namespace Core.Mapping.UnitTypes;

public partial class UnitTypesProfile : Profile
{
    public UnitTypesProfile()
    {
        GetUnitTypesMapping();
        GetUnitTypeMapping();
    }
}
