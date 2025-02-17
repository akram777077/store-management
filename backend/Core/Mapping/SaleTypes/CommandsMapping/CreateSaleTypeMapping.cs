using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.SaleTypes.Commands.Requests;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.SaleTypes
{
    public partial class SaleTypeProfile
    {
        private void CreateSaleTypeMapping()
        {
            CreateMap<CreateSaleTypeCommand, SaleType>();
        }
    }
}
