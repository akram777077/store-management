using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Queries.Resquests
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<GetCategoriesListResponse>>>
    {
    }
}
