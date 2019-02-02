# ZarinPal .NET SDK 


### Getting Started
Open your project and go to `nuget` then Search `Zarinpal` when found it install library.

### Requirement
 .NET 4.5.1 framework is Require

### Example for Payment Request Page:
```C#
   var zarinpal = ZarinPal.ZarinPal.Get();  // Create a new Instance of ZarinPal by Get() method.
   String merchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";  // Your merchant id.
   long amount = 1000; // This's amout of payment in TOMAN unit.
   String callbackURL = "http://localhost:65309/VerficationPage.aspx"; //This's is your callback url that payment result       (success or failure payment) redirect to it.
   String description = "Payment request by .NET SDK."; //This's your description of payment.


   // Create new Payment Request and puts above declared variables. if You will use `sandbox` set true value in last argument.
   var payemntRequest = new PaymentRequest(
                        merchantID, 
                        amount, 
                        callbackURL, 
                        description, 
                        false);
   var response = zarinpal.GetAuthorityPayment(payemntRequest); // Invoke this method that get Authority to you if your payment request be correct.


        //this conidiction check if 'status' equal 100 then you can load zarinpal payment gateway page 
        if (response.Status == 100)
        {
            Response.Redirect(response.PaymentURL); // by this method load Payment page
        }
        else
        {
            System.Diagnostics.Debug.Print("Request has failure code:" + response.Status);
        }
        
        
```

### Example for Verfication Payment Page:
```C#
        var zarinpal = ZarinPal.ZarinPal.Get();
        var response = zarinpal.VerifyPayment(this.ClientQueryString);
        if (response.IsSuccess)
        {
            Response.Write(String.Format("<script>alert('Purchase successfully with ref transaction {0}')</script>",   response.RefID));
        }
        else
        {
            Response.Write("<script>alert('Purchase unsuccessfully')</script>");

        }
```
