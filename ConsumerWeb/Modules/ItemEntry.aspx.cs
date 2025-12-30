using System;
using System.Data;

public partial class Modules_ItemEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
            PopulateFields();
        }
    }

    private void BindGridView()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("BarCode");
        dt.Columns.Add("ItemDescription");
        dt.Columns.Add("Qty");
        dt.Columns.Add("SchemeQty");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Value");
        dt.Columns.Add("MRP");
        dt.Columns.Add("GST");
        dt.Columns.Add("SaleRate");
        dt.Columns.Add("ProfMargin");

        dt.Rows.Add("123456", "Item A", "10", "2", "100", "1000", "120", "18%", "110", "5%");
        dt.Rows.Add("789012", "Item B", "5", "1", "200", "1000", "220", "12%", "210", "6%");
        dt.Rows.Add("345678", "Item C", "8", "0", "150", "1200", "180", "18%", "160", "4%");
        dt.Rows.Add("901234", "Item D", "12", "3", "80", "960", "95", "5%", "90", "3%");
        dt.Rows.Add("567890", "Item E", "7", "2", "130", "910", "145", "18%", "135", "7%");

        gvItems.DataSource = dt;
        gvItems.DataBind();
    }

    private void PopulateFields()
    {
        txtPONo.Text = "PO12345";
        txtPODate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        txtDistributorCode.Text = "D-001";
        txtVendorSalesman.Text = "John Doe";
        txtEmployeeCode.Text = "EMP-1001";
        txtPaymentTerms.Text = "30 Days";
        txtExtraDiscount.Text = "5%";
        txtTaxableAmount.Text = "10,000";
        txtGSTAmount.Text = "1,800";
        txtTotalAmount.Text = "11,800";
    }
}
