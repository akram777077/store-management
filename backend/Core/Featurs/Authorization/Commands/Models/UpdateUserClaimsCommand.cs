using Core.Bases;
using Data.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsResquest, IRequest<Response<string>>
    {
    }
}
