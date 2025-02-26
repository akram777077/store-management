﻿using System;
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
            public const string GetById = Prefix + "{id:int}";
            public const string GetByName = Prefix + "{name}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "update/{id}";
            public const string Delete = Prefix + "Delete/" + "{Id}";
        }
    }
}
