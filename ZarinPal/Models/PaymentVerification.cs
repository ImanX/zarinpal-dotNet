namespace ZarinPal
{
    public class PaymentVerification
    {
        public long Amount { private set; get; }
        public string MerchantID { private set; get; }
        public string Authority { private set; get; }

        public PaymentVerification(string MerchantID, long Amount, string Authority)
        {
            this.Amount = Amount;
            this.MerchantID = MerchantID;
            this.Authority = Authority;
        }
    }
}
