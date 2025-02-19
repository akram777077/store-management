using AutoMapper;
using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.PaymentMethods.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.PaymentMethods
{
    public partial class PaymentMethodProfile
    {
        public void CreatePaymentMethodMapping()
        {
            CreateMap<CreatePaymentMethodCommand, PaymentMethod>()
                .ForMember(dest => dest.MethodName, opt => opt.MapFrom(src => src.Name));
        }
    }

}