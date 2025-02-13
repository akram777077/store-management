using Core.Bases;
using Core.Featurs.PaymentMethods.Query.Response;
using MediatR;

namespace Core.Featurs.PaymentMethods.Query.Request
{
    public class GetPaymentMethodByNameRequest(string name) : IRequest<Response<GetPaymentMethodResponse>>
    {
        public string Name { get; set; } = name;
    }
}
