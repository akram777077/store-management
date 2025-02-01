﻿using Core.Featurs.Categories.Queries.Responses;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Categories
{
    public partial class CategoryProfile
    {
        private void GetCategoriesListMapping()
        {
            CreateMap<Category, GetCategoriesListResponse>();
        }
    }
}
