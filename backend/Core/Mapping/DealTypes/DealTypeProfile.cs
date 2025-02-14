using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.DealTypes
{
    public partial class DealTypeProfile : Profile
    {
        public DealTypeProfile()
        {
            GetDealTypeMapping();
            DealTypeCommandMapping();
        }
    }
}
