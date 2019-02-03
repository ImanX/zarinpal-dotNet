using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarinPal
{
    public class VerificationRequest
    {
        public long Amount { private set; get; }
        public String MerchantID { private set; get; }
        public String Authority { private set; get; }


        public VerificationRequest(String MerchantID, long Amount, String Authority)
        {
            this.Amount = Amount;
            this.MerchantID = MerchantID;
            this.Authority = Authority;
        }
    }
}
