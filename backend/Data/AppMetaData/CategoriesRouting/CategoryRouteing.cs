using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppMetaData
{
    public static partial class Router
    {
        public static class CategoryRouteing
        {
            public const string Prefix = "Categories/";
            public const string List = Prefix + "List";
            public const string Paginated = Prefix + "Paginated";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/" + "{Id}";
        }
    }
}
