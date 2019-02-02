using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//import ZarinPal Assembly for us ZarinPal Classes
using ZarinPal;
public partial class PurchasePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var zarinpal = ZarinPal.ZarinPal.Get();  // Create a new Instance of ZarinPal by Get() method.

        String merchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";  // Your merchant id.
        long amount = 1000; // This's amout of payment in TOMAN unit.
        String callbackURL = "http://localhost:65309/VerficationPage.aspx"; //This's is your callback url that payment result (success or failure payment) redirect to it.
        String description = "Payment request by .NET SDK."; //This's your description of payment.



        var payemntRequest = new PaymentRequest(merchantID, amount, callbackURL, description,false); // Create new Payment Request and puts above declared variables.
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
    
    }
}