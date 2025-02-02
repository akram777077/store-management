using System;

namespace Core.Featurs.UnitType.Query.Response;

public class GetUnitTypesResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
