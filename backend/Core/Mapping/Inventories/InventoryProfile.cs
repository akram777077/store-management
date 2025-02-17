using AutoMapper;

namespace Core.Mapping.Inventories
{
    public partial class InventoryProfile : Profile
    {
        public InventoryProfile() 
        {
            GetInventoriesMapping();
        }
    }
}
