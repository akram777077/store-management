using Core.Bases;
using Core.Featurs.Inventories.Queries.Response;
using MediatR;

namespace Core.Featurs.Inventories.Queries.Requests
{
    public class GetInventoriesByLocationQuery : IRequest<Response<GetInventoriesResponse>>
    {
        public string Location { set; get;}

        public GetInventoriesByLocationQuery(string location)
        {
            Location = location;
        }
    }
}
