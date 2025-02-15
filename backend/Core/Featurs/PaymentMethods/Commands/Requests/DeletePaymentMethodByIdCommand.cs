using Core.Bases;
using MediatR;

namespace Core.Featurs.PaymentMethods.Commands.Requests
{
    public class DeletePaymentMethodByIdCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }

}
