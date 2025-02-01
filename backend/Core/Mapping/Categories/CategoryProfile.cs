using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Categories
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            GetCategoriesListMapping();
            CreateCategoryMapping();
        }
    }
}
