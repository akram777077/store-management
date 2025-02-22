using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppMetaData
{
    public static partial class Router
    {
    
        public class UserRouting
    
        {
            public const string Prefix = "Users/";
    
            public const string List = Prefix + "List";
        
            public const string GetById = Prefix + "GetById/{Id}";
    
            public const string GetByEmail = Prefix + "GetByEmail/{Email}";

            public const string GetByPhoneNumber = Prefix + "GetByPhoneNumber/{PhoneNumber}";

            public const string GetByUsername = Prefix + "GetByUsername/{Username}";
    
            public const string Create = Prefix + "Create";

            public const string Update = Prefix + "update/{id}";

            public const string ChangePassword = Prefix + "ChangePassword/{id}";
    
            public const string Delete = Prefix + "Delete/" + "{Id}";
            public const string UnDelete = Prefix + "UnDelete/" + "{Id}";
    
        }
    }
}
