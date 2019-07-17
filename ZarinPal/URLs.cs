namespace ZarinPal
{
    internal class URLs
    {
        private const string PAYMENT_REQ_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
        private const string PAYMENT_PG_URL = "https://{0}zarinpal.com/pg/StartPay/{1}/ZarinGate";
        private const string PAYMENT_VERIFICATION_URL = "https://{0}zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
        private const string SAND_BOX = "sandbox.";
        private const string WWW = "www.";

        public bool IsSandBox { set; private get; }

        public URLs(bool isSandbox)
        {
            this.IsSandBox = isSandbox;
        }

        public string GetPaymentRequestURL()
        {
            return string.Format(PAYMENT_REQ_URL, (IsSandBox ? SAND_BOX : WWW));
        }

        public string GetPaymenGatewayURL(string Authority)
        {
            return string.Format(PAYMENT_PG_URL, (IsSandBox ? SAND_BOX : WWW), Authority);
        }

        public string GetVerificationURL()
        {
            return string.Format(PAYMENT_VERIFICATION_URL, (IsSandBox ? SAND_BOX : WWW));
        }
    }
}
