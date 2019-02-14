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




        private static ZarinPal _ZarinPal;
        private HttpCore _HttpCore;
        private Boolean IsSandBox;
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


        public void EnableSandboxMode()
        {
            this.IsSandBox = true;
        }

        public void DisableSandboxMode()
        {
            this.IsSandBox = false;
        }


        public PaymentResponse InvokePaymentRequest(PaymentRequest PaymentRequest)
        {
            URLs url = new URLs(this.IsSandBox);
            _HttpCore.URL = url.GetPaymentRequestURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = PaymentRequest;
            this.PaymentRequest = PaymentRequest;
            String response = _HttpCore.Get();

            JavaScriptSerializer j = new JavaScriptSerializer();
            PaymentResponse _Response = j.Deserialize<PaymentResponse>(response);
            _Response.PaymentURL = url.GetPaymenGatewayURL(_Response.Authority);

            return _Response;
        }


        public VerificationResponse InvokePaymentVerification(PaymentVerification verificationRequest)
        {
            URLs url = new URLs(this.IsSandBox);
            _HttpCore.URL = url.GetVerificationURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = verificationRequest;


            String response =  _HttpCore.Get();
            JavaScriptSerializer j = new JavaScriptSerializer();
            VerificationResponse verification = j.Deserialize<VerificationResponse>(response);
            return verification;

        }





    }

}