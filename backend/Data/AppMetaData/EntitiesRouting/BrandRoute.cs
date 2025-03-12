namespace Data.AppMetaData;

public static partial class Router
{
    public static class BrandRoute
    {
        private const string Prefix = "brands/";
        public const string GetBrands = Prefix + "list";
        public const string GetById = Prefix + "id=" + "{id:int}";
        public const string Update = Prefix + "update/id=" + "{id:int}";
        public const string Create = "brands/create";
        public const string Delete = Prefix + "delete/id=" + "{id:int}";
    }
}