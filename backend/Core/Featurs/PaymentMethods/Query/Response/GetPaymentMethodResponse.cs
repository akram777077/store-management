using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.PaymentMethods.Query.Response
{
    public class GetPaymentMethodResponse
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
