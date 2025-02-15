using AutoMapper;
using Core.Featurs.Brands.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Brands
{
    public partial class BrandProfile : Profile
    {
        public BrandProfile()
        {
            GetBrandMapping();
            CreateBrandMapping();
            EditBrandMapping();
        }
    }
}
