using System;
using AutoMapper;

namespace Core.Mapping.UnitTypes;

public partial class UnitTypeProfile : Profile
{
    public UnitTypeProfile()
    {
        GetUnitTypeMapping();
        UnitTypeOnlyMapping();
    }
}
