using Core.Bases;
using Core.Featurs.PaymentMethods.Query.Response;
using MediatR;

namespace Core.Featurs.PaymentMethods.Query.Request
{
    public class GetPaymentMethodByIdRequest(long id) : IRequest<Response<GetPaymentMethodResponse>>
    {
        public long Id { get; set; } = id;
    }
}
