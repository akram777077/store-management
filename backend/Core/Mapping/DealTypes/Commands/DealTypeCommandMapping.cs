using System;
using Core.Featurs.DealTypes.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.DealTypes
{
    public partial class DealTypeProfile
    {
        public void DealTypeCommandMapping()
        {
            CreateMap<DealTypeBaseCommand, DealType>();
        }
    }
}
