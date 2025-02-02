using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Queries.Resquests
{
    public class GetCategoryByNameQuery : IRequest<Response<GetCategoriesResponse>>
    {
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
