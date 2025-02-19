namespace Data.AppMetaData;

public partial class Router
{
    public class PaymentMethodRouting
    {
        public const string Prefix = "PaymentMethods/";
        public const string List = Prefix + "List";
        public const string GetByName = Prefix + "name/{name}";
        public const string GetById = Prefix + "id={id}";
        public const string Add = Prefix + "Add";
        public const string Update = Prefix + "Update/{id}";
        public const string Delete = Prefix + "Delete/{id}";
    }
}