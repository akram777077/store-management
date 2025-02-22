using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Requests
{
    public class UpdateUserBaseCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
    public class UpdateUserCommand : UpdateUserBaseCommand
    {
        public required string Id { get; set; }

    }
}
