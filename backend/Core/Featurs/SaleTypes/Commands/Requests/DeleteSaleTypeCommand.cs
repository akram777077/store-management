using Core.Bases;
using MediatR;

namespace Core.Featurs.SaleTypes.Commands.Requests
{
    public class DeleteSaleTypeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}