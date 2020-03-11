using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarinPal
{
    class URLs
    {
        public Boolean IsSandBox { set; private get; }
        private Boolean IsWithExtra;


        private const String PAYMENT_REQ_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentRequest{1}.json";
        private const String PAYMENT_PG_URL = "https://{0}zarinpal.com/pg/StartPay/{1}/ZarinGate";
        private const String PAYMENT_VERIFICATION_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentVerification{1}.json";
        private const String SAND_BOX = "sandbox.";
        private const String WWW = "www.";
        private const String WITH_EXTRA = "WithExtra";





        public URLs(Boolean IsSandBox,Boolean IsWithExtra)
        {
            this.IsSandBox = IsSandBox;
            this.IsWithExtra = IsWithExtra;
        }

        public URLs(Boolean IsSandBox)
        {
            this.IsSandBox = IsSandBox;
        }
     
        
      


        public String GetPaymentRequestURL()
        {
            return String.Format(PAYMENT_REQ_URL,  (IsSandBox ? SAND_BOX : WWW),(IsWithExtra ? WITH_EXTRA : ""));
        }

        public String GetPaymenGatewayURL(String Authority)
        {
            return String.Format(PAYMENT_PG_URL, (IsSandBox ? SAND_BOX :WWW),Authority);

        }

        public String GetVerificationURL()
        {
            return String.Format(PAYMENT_VERIFICATION_URL, (IsSandBox ? SAND_BOX : WWW), (IsWithExtra ? WITH_EXTRA : ""));

        }

        
 
       
        


    }
}
