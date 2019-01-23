using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Web;

namespace ZarinPal
{

    public class ZarinPal
    {


        private HttpCore _HttpCore;
        private static ZarinPal _ZarinPal;
        public PaymentRequest PaymentRequest { get; private set; }


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
            this.PaymentRequest = PaymentRequest;
            String response = _HttpCore.Get();

            JavaScriptSerializer j = new JavaScriptSerializer();
            PaymentResponse _Response = j.Deserialize<PaymentResponse>(response);
            _Response.URLPayment = "https://www.zarinpal.com/pg/StartPay/" + _Response.Authority;

            return _Response;
        }


        public VerificationResponse VerifyPayment(String queryString)
        {
          

         

            VerificationResponse _Response = new VerificationResponse(HttpUtility.ParseQueryString(queryString));
            if (!_Response.IsSuccess) return _Response;

            _Response.Amount = PaymentRequest.Amount;
            _Response.MerchantID = PaymentRequest.MerchantID;

            _HttpCore.URL = "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = _Response;


           String response =  _HttpCore.Get();

            JavaScriptSerializer j = new JavaScriptSerializer();
            VerificationResponse verification = j.Deserialize<VerificationResponse>(response);
            return verification;

        }





    }

}