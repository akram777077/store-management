using Core.Bases;
using Core.Featurs.Brands.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Brands.Query.Request
{
    public class GetBrandByNameRequest(string name) : IRequest<Response<GetBrandResponse>>
    {
        public string Name { get; set; } = name;
    }
}
