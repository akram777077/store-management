namespace Data.AppMetaData;

public partial class Router
{
    public class SaleTypeRouting
    {
        public const string Prefix = "SaleTypes";
        public const string List = Prefix + "/list";
        public const string GetById = Prefix + "/id={id:long}";
    }
}