using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace ZarinPal
{


    public class PaymentRequest
    {

        public String MerchantID { get; set; }
        public String CallbackURL { get; set; }
        public String Description { get; set; }
        public long Amount { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }


        public PaymentRequest(String MerchantID, long Amount, String CallbackURL, String Description)
        {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.CallbackURL = CallbackURL;
            this.Description = Description;
        }


    }
    
}
