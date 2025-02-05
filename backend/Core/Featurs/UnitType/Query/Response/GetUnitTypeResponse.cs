using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Core.Featurs.UnitType.Query.Response;

public class GetUnitTypeResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}