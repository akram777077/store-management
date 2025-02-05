using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Commands.Requests
{
    public class CreateCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
