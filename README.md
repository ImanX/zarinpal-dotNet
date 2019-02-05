# ZarinPal .NET SDK 


### Getting Started
Open your project and go to `nuget` then search `Zarinpal` when found it install library.

### Requirement
4.5.1 .NET framework is Require

### Example in Payment Request Page:
```C#
           ZarinPal.ZarinPal zarinpal = ZarinPal.ZarinPal.Get();

         String MerchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";
         String CallbackURL = "http://localhost:59701/VerficationPage.aspx";
         long Amount = 100;
         String Description = "This is Test Payment";

         ZarinPal.PaymentRequest pr = new ZarinPal.PaymentRequest(MerchantID, Amount, CallbackURL, Description);

         zarinpal.EnableSandboxMode();
         var res = zarinpal.InvokePaymentRequest(pr);
         if (res.Status == 100) {
             Response.Redirect(res.PaymentURL);
         }
          
```


### Example in Payment Verification Page: 

```C#

            var collection = HttpUtility.ParseQueryString(this.ClientQueryString);
            String Status = collection["Status"];

            if (Status != "OK")
            {
                Response.Write("<script>alert('Purchase unsuccessfully')</script>");
                return;
            }

            var zarinpal = ZarinPal.ZarinPal.Get();

            String Authority = collection["Authority"];
            String MerchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";
            long Amount = 100;

            var pv = new ZarinPal.PaymentVerification(MerchantID, Amount, Authority);
            var verificationResponse = zarinpal.InvokePaymentVerification(pv);
            if (verificationResponse.Status == 100)
            {
                Response.Write(String.Format("<script>alert('Purchase successfully with ref transaction {0}')</script>", verificationResponse.RefID));
            }
            else {

                Response.Write(String.Format("<script>alert('Purchase unsuccessfully Error code is: {0}')</script>",verificationResponse.Status));

            }
          
```
