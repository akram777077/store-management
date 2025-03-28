﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppMetaData
{
    public static partial class Router
    {
        public static class InventoryRoutes
        {
            public const string Prefix = "Inventories/";
            public const string GetById = Prefix + "{id:int}";
            public const string List = Prefix + "List";
            public const string GetByLocation = Prefix + "{location}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update/{id}";
            public const string Delete = Prefix + "Delete/" + "{id}";
        }
    }
}
