using Core.Bases;
using MediatR;

namespace Core.Featurs.Brands.Commands.Requests
{
    public class BrandBaseCommand : IRequest<Response<string>>
    {
        public required string Name { get; set; }
    }
}
