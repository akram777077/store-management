using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.SaleTypes.Commands.Requests
{
    public class SaleTypeBaseCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}