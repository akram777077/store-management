namespace Data.AppMetaData;

public static partial class Router
{
    public class UnitTypesRoute
    {
        public const string Prefix = "/unitTypes/";
        public const string List = Prefix + "List";
        public const string GetByName = Prefix + "name/{name}";
        public const string GetById = Prefix + "id={id}";
        public const string Create = Prefix + "Create";
        public const string Delete = Prefix + "delete/{id}";
        public const string Update = Prefix+ "update/{id}";
    }
}
