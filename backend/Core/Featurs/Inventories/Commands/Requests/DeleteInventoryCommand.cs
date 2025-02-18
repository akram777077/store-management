using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Commands.Requests
{
    public class DeleteInventoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
