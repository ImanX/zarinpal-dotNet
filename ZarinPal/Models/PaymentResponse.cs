
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarinPal
{
   public class PaymentResponse
    {
        public String Authority { set; get; }
        public int Status { set; get; }
        public String PaymentURL { set; get; }

    }
}
