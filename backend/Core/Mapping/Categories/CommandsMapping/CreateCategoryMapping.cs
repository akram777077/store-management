using Core.Featurs.Categories.Commands.Requests;
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
        private void CreateCategoryMapping()
        {
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
