using Core.Bases;
using Core.Featurs.PaymentMethods.Query.Response;
using MediatR;

namespace Core.Featurs.PaymentMethods.Query.Request
{
    public class GetPaymentMethodsListRequest : IRequest<Response<IEnumerable<GetPaymentMethodResponse>>>
    {
    }
}
