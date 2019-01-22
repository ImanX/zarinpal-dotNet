using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

namespace ZarinPal
{

    public class ZarinPal
    {


        private HttpCore _HttpCore;
        private static ZarinPal _ZarinPal;


        private ZarinPal()
        {
            this._HttpCore = new HttpCore();
        }



        public static ZarinPal Get()
        {
            if (_ZarinPal == null)
            {
                _ZarinPal = new ZarinPal();
            }

            return _ZarinPal;
        }


        public PaymentResponse GetAuthorityPayment(PaymentRequest PaymentRequest)
        {
            _HttpCore.URL = "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = PaymentRequest;
            String response = _HttpCore.Get();

            JavaScriptSerializer j = new JavaScriptSerializer();
            PaymentResponse _Response = j.Deserialize<PaymentResponse>(response);
            _Response.URLPayment = "https://www.zarinpal.com/pg/StartPay/"+_Response.Authority;

            return _Response;
         
        }


       



    }

}