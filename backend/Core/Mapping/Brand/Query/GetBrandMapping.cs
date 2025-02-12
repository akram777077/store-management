using AutoMapper;
using Core.Featurs.Brands.Query.Response;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Brands
{
    public partial class BrandProfile : Profile
    {
        public void GetBrandMapping()
        {
            CreateMap<Brand, GetBrandResponse>();
        }
    }
}
