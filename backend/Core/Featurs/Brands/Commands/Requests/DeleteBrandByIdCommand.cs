using Core.Bases;
using MediatR;

namespace Core.Featurs.Brands.Commands.Requests
{
    public class DeleteBrandByIdCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
