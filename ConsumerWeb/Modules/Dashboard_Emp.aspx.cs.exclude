using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Dashboard_Emp : System.Web.UI.Page
{
    string token = string.Empty;
    public static string BG_IMAGEIN = string.Empty;
    public static string LOGO = string.Empty;
    public static string CorporateCode = string.Empty;
    public static string VirtualPath = string.Empty;
    public static string VirtualPathExit = string.Empty;
    private decimal grandTotal = 0;
    private int totalQuantity = 0;
    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string itemname = txtSearch.Text;
        DataSet ds = null;
        DataTable dt = null;

        if (!IsPostBack)
        {
            ds = GetMasterData(itemname);
            dt = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                gvItem_list.DataSource = dt;
                gvItem_list.DataBind();
            }
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvOrder_List.DataSource = dt;
                gvOrder_List.DataBind();
            }
            ViewState["TotalSaleRate"] = 0m;
            ViewState["TotalQuantity"] = 0;
            ViewState["TotalGST"] = 0m;
        }
        //else
        //{

        //    if (ViewState["OrderList"] != null)
        //    {
        //        gvOrder_List.DataSource = (DataTable)ViewState["OrderList"];
        //        gvOrder_List.DataBind();
        //    }
        //}
        if (!IsPostBack)
        {
            //totalSaleRate = 0m;
            //totalQuantity = 0;
            //totalGST = 0m;
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindHistoryGrid();
    }
    public DataSet GetMasterData(string ItemName)
    {

        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet preauthData = null;
        try
        {
            cmd = new SqlCommand("Biling_Details_Master", conn1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vITEM_NAME", ItemName);
            da = new SqlDataAdapter(cmd);
            preauthData = new DataSet();
            da.Fill(preauthData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }
        }
        return preauthData;

    }

    protected void gvItem_list_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddItem")
        {
            string itemDesc = e.CommandArgument.ToString();

            // Find the row where the command was triggered
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            string saleRate = row.Cells[3].Text.Trim();
            btnProceedToPayment.Visible = true;
            DataTable dt;
            if (ViewState["OrderList"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("Item_Desc");
                dt.Columns.Add("Sale_Rate", typeof(decimal));
                dt.Columns.Add("Def_Qty", typeof(int));

                // ✅ Add missing columns
                dt.Columns.Add("Total_Price", typeof(decimal));
                dt.Columns.Add("GST", typeof(decimal));
                dt.Columns.Add("Grand_Total", typeof(decimal));
            }
            else
            {
                dt = (DataTable)ViewState["OrderList"];
            }

            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(r => r["Item_Desc"].ToString() == itemDesc);

            if (existingRow != null)
            {
                existingRow["Def_Qty"] = Convert.ToInt32(existingRow["Def_Qty"]) + 1;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Item_Desc"] = itemDesc;
                dr["Sale_Rate"] = Convert.ToDecimal(saleRate);
                dr["Def_Qty"] = 1;

                // ✅ Calculate and store values
                decimal saleRateValue = Convert.ToDecimal(saleRate);
                decimal totalPrice = saleRateValue;
                decimal gstAmount = totalPrice * 0.18m;
                decimal grandTotal = totalPrice + gstAmount;

                dr["Total_Price"] = totalPrice;
                dr["GST"] = gstAmount;
                dr["Grand_Total"] = grandTotal;

                dt.Rows.Add(dr);
            }

            ViewState["OrderList"] = dt;
            gvOrder_List.DataSource = dt;
            gvOrder_List.DataBind();
        }
    }




    //protected void gvOrder_List_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "RemoveItem")
    //    {
    //        string itemDesc = e.CommandArgument.ToString();
    //        DataTable dt = ViewState["OrderList"] as DataTable;
    //        if (dt != null)
    //        {
    //            DataRow rowToDelete = dt.AsEnumerable()
    //                .FirstOrDefault(row => row["Item_Desc"].ToString() == itemDesc);
    //            if (rowToDelete != null)
    //            {
    //                dt.Rows.Remove(rowToDelete);
    //            }
    //            ViewState["OrderList"] = dt;
    //            gvOrder_List.DataSource = dt;
    //            gvOrder_List.DataBind();
    //        }
    //    }

    //}
    protected void gvOrder_List_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "IncreaseQuantity" || e.CommandName == "DecreaseQuantity")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument); // Get the clicked row index
            GridViewRow row = gvOrder_List.Rows[rowIndex];

            // Retrieve the data source from ViewState
            DataTable dt = ViewState["OrderList"] as DataTable;
            if (dt != null)
            {
                string itemDesc = row.Cells[0].Text; // Identify row by item name
                DataRow[] selectedRow = dt.Select("Item_Desc = '" + itemDesc + "'");

                if (selectedRow.Length > 0)
                {
                    int currentQty = Convert.ToInt32(selectedRow[0]["Def_Qty"]);
                    decimal saleRate = Convert.ToDecimal(selectedRow[0]["Sale_Rate"]);

                    // Increase or Decrease Quantity
                    if (e.CommandName == "IncreaseQuantity")
                        currentQty++;
                    else if (e.CommandName == "DecreaseQuantity" && currentQty > 1)
                        currentQty--;

                    // Update values
                    selectedRow[0]["Def_Qty"] = currentQty;
                    decimal rowTotal = saleRate * currentQty;
                    decimal gstAmount = rowTotal * 0.18m;
                    decimal grandTotal = rowTotal + gstAmount;

                    selectedRow[0]["Total_Price"] = rowTotal;
                    selectedRow[0]["GST"] = gstAmount;
                    selectedRow[0]["Grand_Total"] = grandTotal;

                    // Store back in ViewState and refresh GridView
                    ViewState["OrderList"] = dt;
                    gvOrder_List.DataSource = dt;
                    gvOrder_List.DataBind();
                }
            }
        }
    }


    protected void BindHistoryGrid()
    {
        string itemname = txtSearch.Text;
        DataSet ds = null;
        DataTable dt = null;
        try
        {
            ds = GetMasterData(itemname);
            dt = ds.Tables[0];
            if (!string.IsNullOrEmpty(itemname.ToString()))
            {

                if (dt.Rows.Count > 0)
                {
                    gvItem_list.DataSource = dt;
                    gvItem_list.DataBind();
                }
                else
                {
                    gvItem_list.DataSource = ds.Tables[1];
                    gvItem_list.DataBind();
                }
            }
            else
            {
                gvItem_list.DataSource = ds.Tables[1];
                gvItem_list.DataBind();
                if (ViewState["OrderList"] != null)
                {
                    gvOrder_List.DataSource = (DataTable)ViewState["OrderList"];
                    gvOrder_List.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void UpdateItemQuantityInDataSource(string itemDesc, int quantity)
    {

    }
    private void RemoveItemFromDataSource(string itemDesc)
    {

    }

    protected void btnAddmob_Click(object sender, EventArgs e)
    {

    }
    protected void gvOrder_List_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal saleRate = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sale_Rate"));
            int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Def_Qty"));

            decimal rowTotal = saleRate * quantity; // Total for the row
            decimal gstAmount = rowTotal * 0.18m;  // 18% GST
            decimal grandTotal = rowTotal + gstAmount; // Final total after GST

            e.Row.Cells[3].Text = rowTotal.ToString("0.00"); // Total Price
            e.Row.Cells[4].Text = gstAmount.ToString("0.00"); // GST (18%)
            e.Row.Cells[5].Text = grandTotal.ToString("0.00"); // Grand Total

            // Apply highlighting based on conditions
            if (quantity > 1)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.BorderStyle = BorderStyle.Solid;
                e.Row.BorderWidth = Unit.Pixel(2);
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalQty = 0;
            decimal totalAmount = 0, totalGST = 0, grandTotal = 0;

            foreach (GridViewRow row in gvOrder_List.Rows)
            {
                Label lblQty = (Label)row.FindControl("lblQuantity");

                if (lblQty != null)
                {
                    int qty = Convert.ToInt32(lblQty.Text);
                    totalQty += qty;

                    decimal saleRate = Convert.ToDecimal(row.Cells[1].Text);
                    decimal totalPrice = saleRate * qty;
                    decimal gstAmount = totalPrice * 0.18m;
                    decimal rowGrandTotal = totalPrice + gstAmount;

                    totalAmount += totalPrice;
                    totalGST += gstAmount;
                    grandTotal += rowGrandTotal;
                }
            }

            e.Row.Cells[0].Text = "Total:";
            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;

            e.Row.Cells[2].Text = totalQty.ToString();
            e.Row.Cells[2].Font.Bold = true;

            e.Row.Cells[3].Text = totalAmount.ToString("0.00");
            e.Row.Cells[3].Font.Bold = true;

            e.Row.Cells[4].Text = totalGST.ToString("0.00");
            e.Row.Cells[4].Font.Bold = true;

            e.Row.Cells[5].Text = grandTotal.ToString("0.00");
            e.Row.Cells[5].Font.Bold = true;

            // Apply proper alignment
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            // Highlight footer
            e.Row.BackColor = System.Drawing.Color.LightGray;
            e.Row.Font.Bold = true;
        }
    }


    //protected void gvOrder_List_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        decimal saleRate = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sale_Rate"));
    //        int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Def_Qty"));

    //        decimal rowTotal = saleRate * quantity; // Calculate total for this row
    //        decimal gstAmount = rowTotal * 0.18m;  // 18% GST
    //        decimal grandTotal = rowTotal + gstAmount; // Final total after GST

    //        e.Row.Cells[3].Text = rowTotal.ToString("0.00"); // Total Price
    //        e.Row.Cells[4].Text = gstAmount.ToString("0.00"); // GST (18%)
    //        e.Row.Cells[5].Text = grandTotal.ToString("0.00"); // Grand Total

    //    }




    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        int totalQty = 0;
    //        decimal totalAmount = 0, totalGST = 0, grandTotal = 0; decimal rowTotal = 0; decimal saleRate = 0;

    //        // Loop through GridView rows to calculate totals dynamically
    //        foreach (GridViewRow row in gvOrder_List.Rows)
    //        {
    //            Label lblQty = (Label)row.FindControl("lblQuantity");
    //            Label grdtotal = (Label)row.FindControl("grdtotal");
    //            if (lblQty != null)
    //            {
    //                int qty = Convert.ToInt32(lblQty.Text);
    //                totalQty += qty;

    //                saleRate = Convert.ToDecimal(DataBinder.Eval(row.DataItem, "Grand_total"));
    //                decimal totalPrice = saleRate * qty;

    //                totalAmount += totalPrice;
    //                totalGST += totalPrice * 0.18M;  // 18% GST
    //                grandTotal += totalPrice + (totalPrice * 0.18M);
    //                rowTotal = saleRate * totalQty;
    //            }
    //        }

    //        //// Display totals in the footer
    //        //e.Row.Cells[2].Text = "Total:";
    //        //e.Row.Cells[3].Text = totalQty.ToString();  // Total Quantity
    //        //e.Row.Cells[4].Text = totalAmount.ToString("0.00");  // Total Amount
    //        //e.Row.Cells[5].Text = totalGST.ToString("0.00");  // GST 18%
    //        ////e.Row.Cells[6].Text = grandTotal.ToString("0.00");  // Grand Total

    //        //e.Row.Font.Bold = true;


    //        e.Row.Cells[0].Text = "Total:";
    //        e.Row.Cells[0].Font.Bold = true;
    //        e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left; // Align "Total:" text to the left

    //        e.Row.Cells[2].Text = totalQty.ToString(); // Total Quantity
    //        e.Row.Cells[2].Font.Bold = true;

    //        //e.Row.Cells[3].Text = rowTotal.ToString("0.00"); // Total Sale Rate
    //        //e.Row.Cells[3].Font.Bold = true;

    //        //e.Row.Cells[4].Text = totalGST.ToString("0.00"); // GST (18%)
    //        //e.Row.Cells[4].Font.Bold = true;

    //        e.Row.Cells[5].Text = grandTotal.ToString("0.00"); // Grand Total
    //        e.Row.Cells[5].Font.Bold = true;

    //        // Apply proper alignment if needed
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
    //    }
    //}





    protected void btnProceedToPayment_Click(object sender, EventArgs e)
    {
        Session["ShowQRCode"] = true;  // Store session value to show QR
        Response.Redirect("../Payment/Payment.aspx");
    }

}