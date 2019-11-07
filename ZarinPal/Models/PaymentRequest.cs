namespace ZarinPal
{
    public class PaymentRequest
    {
        public string MerchantID { get; set; }
        public string CallbackURL { get; set; }
        public string Description { get; set; }
        public long Amount { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public PaymentRequest(string MerchantID, long Amount, string CallbackURL, string Description)
        {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.CallbackURL = CallbackURL;
            this.Description = Description;
        }
    }
}
