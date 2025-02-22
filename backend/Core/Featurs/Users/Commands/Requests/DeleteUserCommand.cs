using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Requests
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public required string Id { get; set; }

    }
}
