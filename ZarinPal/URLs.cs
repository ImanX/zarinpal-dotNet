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


        private String PAYMENT_REQ_URL = String.Format("https://www.{0}zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
        private const String PAYMENT_PG_URL = "https://www.{0}zarinpal.com/pg/StartPay";
        private const String PAYMENT_VERIFICATION_URL = "https://www.{0}zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
        private const String SAND_BOX = "sandbox";


        public URLs(Boolean IsSandBox)
        {
            this.IsSandBox = IsSandBox;
        }
      


        public String GetPaymentRequestURL()
        {
            return String.Format(PAYMENT_REQ_URL,  (IsSandBox ? SAND_BOX : ""));
        }

        public String GetPaymenGatewayURL()
        {
            return String.Format(PAYMENT_PG_URL, (IsSandBox ? SAND_BOX : ""));

        }

        public String GetVerificationURL()
        {
            return String.Format(PAYMENT_VERIFICATION_URL, (IsSandBox ? SAND_BOX : ""));

        }

        
 
       
        


    }
}
