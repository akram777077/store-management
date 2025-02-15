using AutoMapper;
using Core.Featurs.Brands.Commands.Requests;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Brands
{
    public partial class BrandProfile
    {
        private void CreateBrandMapping()
        {
            CreateMap<CreateBrandCommand, Brand>();
        }
    }
}
