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


        private const String PAYMENT_REQ_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
        private const String PAYMENT_PG_URL = "https://{0}zarinpal.com/pg/StartPay/{1}/ZarinGate";
        private const String PAYMENT_VERIFICATION_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
        private const String SAND_BOX = "sandbox.";
        private const String WWW = "www.";



        public URLs(Boolean IsSandBox)
        {
            this.IsSandBox = IsSandBox;
        }
      


        public String GetPaymentRequestURL()
        {
            return String.Format(PAYMENT_REQ_URL,  (IsSandBox ? SAND_BOX : WWW));
        }

        public String GetPaymenGatewayURL(String Authority)
        {
            return String.Format(PAYMENT_PG_URL, (IsSandBox ? SAND_BOX :WWW),Authority);

        }

        public String GetVerificationURL()
        {
            return String.Format(PAYMENT_VERIFICATION_URL, (IsSandBox ? SAND_BOX : WWW));

        }

        
 
       
        


    }
}
