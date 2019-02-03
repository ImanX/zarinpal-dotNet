using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZarinPal; //import ZarinPal Assembly for us ZarinPal Classes

public partial class PurchasePage : System.Web.UI.Page
{
    
    protected void Button1_Click(object sender, EventArgs e)
    {
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
          
    }
}