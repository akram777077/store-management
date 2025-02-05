namespace Data.AppMetaData;

public static partial class Router
{
    public class UnitTypesRoute
    {
        public const string Prefix = "/unitTypes/";
        public const string GetUnitTypeByName = Prefix + "nam/{name}";
        public const string GetUnitTypeById = Prefix + "id={id}";
        public const string DeleteById = Prefix + "delete/{id}";
        public const string UpdateById = Prefix+ "update/{id}";
    }
}
