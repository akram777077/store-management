using AutoMapper;
using Core.Featurs.PaymentMethods.Commands.Requests;
using Data.Entities;

namespace Core.Mapping.PaymentMethods
{
    public partial class PaymentMethodProfile
    {
        public void EditPaymentMethodMapping()
        {
            CreateMap<UpdatePaymentMethodCommand, PaymentMethod>()
                .ForMember(dest => dest.MethodName, opt => opt.MapFrom(src => src.Name));
        }
    }
}