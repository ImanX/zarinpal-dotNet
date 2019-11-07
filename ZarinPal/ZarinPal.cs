using Newtonsoft.Json;

namespace ZarinPal
{
    public class ZarinPal
    {
        private static ZarinPal _ZarinPal;
        private HttpCore _HttpCore;
        private bool IsSandBox;
        public PaymentRequest PaymentRequest { get; private set; }

        private ZarinPal()
        {
            _HttpCore = new HttpCore();
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
            IsSandBox = true;
        }

        public void DisableSandboxMode()
        {
            IsSandBox = false;
        }

        public PaymentResponse InvokePaymentRequest(PaymentRequest PaymentRequest)
        {
            URLs url = new URLs(IsSandBox);
            _HttpCore.URL = url.GetPaymentRequestURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = PaymentRequest;
            this.PaymentRequest = PaymentRequest;
            string response = _HttpCore.Get();

            PaymentResponse _Response = JsonConvert.DeserializeObject<PaymentResponse>(response);
            _Response.PaymentURL = url.GetPaymenGatewayURL(_Response.Authority);

            return _Response;
        }

        public VerificationResponse InvokePaymentVerification(PaymentVerification verificationRequest)
        {
            URLs url = new URLs(IsSandBox);
            _HttpCore.URL = url.GetVerificationURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = verificationRequest;


            string response = _HttpCore.Get();
            VerificationResponse verification = JsonConvert.DeserializeObject<VerificationResponse>(response);
            return verification;
        }
    }
}