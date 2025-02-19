using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.PaymentMethods.Commands.Requests
{
    public class PaymentMethodBaseCommand : IRequest<Response<string>>
    {
        public required string Name { get; set; }
    }
}
