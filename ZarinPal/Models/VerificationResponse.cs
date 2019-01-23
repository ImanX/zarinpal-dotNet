using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ZarinPal
{
    public class VerificationResponse
    {

        public bool IsSuccess { get; set; }
        public String Authority { get; set; }
        public String RefID { get; set; }
        public int Status { get; set; }
        public long Amount { get; set; }
        public String MerchantID { get; set; }

        public VerificationResponse(System.Collections.Specialized.NameValueCollection Collection)
        {
            this.IsSuccess = Collection["Status"] == "OK";
            this.Authority = Collection["Authority"];

        }

        public VerificationResponse()
        {

        }
    }
}
