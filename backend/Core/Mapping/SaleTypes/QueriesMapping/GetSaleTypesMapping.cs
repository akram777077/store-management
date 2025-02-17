using Core.Featurs.SaleTypes.Query.Response;
using Data.Entities;

namespace Core.Mapping.SaleTypes
{
    public partial class SaleTypeProfile
    {
        private void GetSaleTypesMapping()
        {
            CreateMap<SaleType, GetSaleTypesResponse>();
        }
    }
}
