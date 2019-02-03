# ZarinPal .NET SDK 


### Getting Started
Open your project and go to `nuget` then search `Zarinpal` when found it install library.

### Requirement
Requirment 4.5.1 .NET framework

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


### Example in Payemn Verification Page: 

```C#
        ZarinPal.ZarinPal zarinpal = ZarinPal.ZarinPal.Get();
        String MerchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";
        String Authority = HttpUtility.ParseQueryString(this.ClientQueryString)["Authority"];
        long Amount = 100;

        if (HttpUtility.ParseQueryString(this.ClientQueryString)["Authority"].Equals("OK"))
        {
            var pv = new ZarinPal.VerificationRequest(MerchantID, Amount, Authority);

            zarinpal.EnableSandboxMode();
            var res = zarinpal.InvokeVerificationPayment(pv);
            if (res.Status == 100)
            {
                Response.Write(String.Format("<script>alert('Purchase successfully with ref transaction {0}')</script>", res.RefID));
            }
            else {
                Response.Write(String.Format("<script>alert('Purchase unsuccessfully Error code is: {0}')</script>",res.Status));
            }
        }
          
```
