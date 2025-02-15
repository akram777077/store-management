using AutoMapper;
using Core.Featurs.PaymentMethods.Query.Response;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.PaymentMethods
{
    public partial class PaymentMethodProfile
    {
        public void GetPaymentMethodMapping()
        {
            CreateMap<PaymentMethod, GetPaymentMethodResponse>();
        }
    }
}
