using AutoMapper;
using Core.Featurs.DealTypes.Query.Response;
using Data.Entities;

namespace Core.Mapping.DealTypes
{
    public partial class DealTypeProfile : Profile
    {
        public void GetDealTypeMapping()
        {
            CreateMap<DealType, GetDealTypeResponse>();
        }
    }
}
