using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerficationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ZarinPal.ZarinPal zarinPal = ZarinPal.ZarinPal.Get();
        ZarinPal.VerificationResponse res = zarinPal.VerifyPayment(this.ClientQueryString);
        if (res.IsSuccess)
        {

           
            Response.Write(String.Format("<script>alert('Purchase successfully with ref transaction {0}')</script>",res.RefID));

        }
        else
        {
            Response.Write("<script>alert('Purchase unsuccessfully')</script>");

        }

    }
}