using System;
using System.Web.UI;

public partial class Payment_Payment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ShowQRCode"] != null && (bool)Session["ShowQRCode"])
            {
                pnlQRCode.Visible = true;  // Show QR code
                Session["ShowQRCode"] = null; // Clear session after showing
            }
            else
            {
                pnlQRCode.Visible = false; // Hide QR if accessed directly
            }
        }
    }

    protected void btnPaymentDone_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderSummary.aspx");  // Redirect to order confirmation page
    }
}
