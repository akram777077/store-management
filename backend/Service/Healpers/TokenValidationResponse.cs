using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Healpers
{
    public class TokenValidationResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } // e.g., "AlgorithmIsWrong"
        public string? UserId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
