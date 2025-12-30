using System;
using System.Data;
using System.Web.UI;

public partial class Modules_FrmSMBill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize controls or load data
            LoadBillItems();
        }
    }

    private void LoadBillItems()
    {
        // Load bill items into the grid
        DataTable dt = new DataTable();
        dt.Columns.Add("ItemCode");
        dt.Columns.Add("ItemName");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Amount");

        // Add sample data
        dt.Rows.Add("001", "Item 1", 2, 100, 200);
        dt.Rows.Add("002", "Item 2", 1, 150, 150);

        GvBillItems.DataSource = dt;
        GvBillItems.DataBind();
    }

    protected void BtnBillNoHelp_Click(object sender, EventArgs e)
    {
        // Handle Bill No Help button click
    }

    protected void BtnBillDateHelp_Click(object sender, EventArgs e)
    {
        // Handle Bill Date Help button click
    }

    protected void BtnCustCodeHelp_Click(object sender, EventArgs e)
    {
        // Handle Customer Code Help button click
    }

    protected void BtnOrderIDHelp_Click(object sender, EventArgs e)
    {
        // Handle Order ID Help button click
    }

    protected void BtnHoldBill_Click(object sender, EventArgs e)
    {
        // Handle Hold Bill button click
    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        // Handle Close button click
    }

    protected void BtnUploadBill_Click(object sender, EventArgs e)
    {
        // Handle Upload Bill button click
    }
}