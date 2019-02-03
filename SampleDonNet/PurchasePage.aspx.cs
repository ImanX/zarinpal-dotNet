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
         ZarinPal.ZarinPal z = ZarinPal.ZarinPal.Get();
            ZarinPal.PaymentRequest pr = new ZarinPal.PaymentRequest("71c705f8-bd37-11e6-aa0c-000c295eb8fc", 100, "http://localhost:49841/VerificationPage.aspx", "Test");

            z.EnableSandboxMode();
            var res = z.InvokePaymentRequest(pr);
            if (res.Status == 100) {
                Response.Redirect(res.PaymentURL);
            }
          
    }
}