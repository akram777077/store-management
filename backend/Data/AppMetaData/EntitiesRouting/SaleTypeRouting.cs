namespace Data.AppMetaData;

public partial class Router
{
    public class SaleTypeRouting
    {
        public const string Prefix = "SaleTypes";
        public const string List = Prefix + "/list";
        public const string GetById = Prefix + "/id={id:long}";
        public const string GetByName = Prefix + "/name/{name}";
        public const string Create = Prefix + "/create";
        public const string Update = Prefix + "/update/{id:long}";
    }
}