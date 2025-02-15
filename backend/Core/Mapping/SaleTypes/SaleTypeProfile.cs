using AutoMapper;
using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.Categories.Queries.Responses;
using Core.Featurs.SaleTypes.Query.Response;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.SaleTypes
{
    public partial class SaleTypeProfile : Profile
    {
        public SaleTypeProfile()
        {
            GetSaleTypesMapping();
            CreateSaleTypeMapping();
            EditSaleTypeMapping();
        }
    }
   
}


