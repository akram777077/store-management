using Core.Featurs.SaleTypes.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.SaleTypes
{
    public partial class SaleTypeProfile
    {
        private void EditSaleTypeMapping()
        {
            CreateMap<UpdateSaleTypeCommand, SaleType>();
        }
    }
}
