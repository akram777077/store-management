using System;

namespace Data.AppMetaData;

public static partial class Router
{
    public static class DealTypeRouting
    {
        public const string Prefix = "DealTypes/";
        public const string GetById = Prefix + "id={id:int}";
        public const string GetByName = Prefix + "name/{name}";
        public const string Create = Prefix + "create";
        public const string List = Prefix + "list";
    }
}
