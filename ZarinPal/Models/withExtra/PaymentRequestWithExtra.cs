using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarinPal
{
   public class PaymentRequestWithExtra : PaymentRequest
    {
        public Object AdditionalData {get;set;}

        public PaymentRequestWithExtra(String MerchantID, long Amount, String CallbackURL, String Description,Object AdditionalData):
            base(MerchantID , Amount , CallbackURL , Description){
                this.AdditionalData = AdditionalData;
        }
    }
}
