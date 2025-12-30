using System;
using System.Data;
using System.Web.UI;

public partial class OrderSummary : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrderDetails();
        }
    }

    private void LoadOrderDetails()
    {
        // Fetch order details from session or database (for demo, using static values)
        lblBillNo.Text = "560607013-001194";
        lblOrderDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        lblTotalAmount.Text = "458.18"; // Example total amount

        // Load purchased items (Replace with database fetch logic)
        DataTable dt = new DataTable();
        dt.Columns.Add("ItemName");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Total");

        dt.Rows.Add("CHANA BIG - 500g", "1", "46.50", "46.50");
        dt.Rows.Add("L W MOONG - 1.594kg", "1.594", "96.50", "153.82");
        dt.Rows.Add("TATA SALT - 1kg", "1", "18.00", "18.00");

        gvPurchasedItems.DataSource = dt;
        gvPurchasedItems.DataBind();
    }

    protected void btnGoHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Modules/Dashboard_Emp.aspx");  // Redirect to the homepage
    }
}
