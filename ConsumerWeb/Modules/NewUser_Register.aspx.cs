using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_NewUser_Register : System.Web.UI.Page
{
    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
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

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string userRole = ddlUserRole.SelectedItem.Value;
        string email = txtEmail.Text.Trim();
        string userId = txtUserID.Text.Trim();

        string action = "INSERT"; 
        int? id = null; 

        if (!string.IsNullOrEmpty(hdnUserID.Value)) 
        {
            action = "UPDATE";
            id = Convert.ToInt32(hdnUserID.Value);
        }

        bool result = ExecuteAdminOperation(action, id, name, email, userRole, userId);

        if (result)
        {
            lblMessage.InnerText = "Operation successful!";
            BindGridView();
        }
        else
        {
            lblMessage.InnerText = "Error occurred!";
        }
    }
    private bool ExecuteAdminOperation(string action, int? id, string name, string email, string role, string userId)
    {
        bool success = false;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AdminOperations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ID", (object)id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserName", name);
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    cmd.Parameters.AddWithValue("@UserRole", role);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                // Log error (you can store this in a log file or database)
                lblMessage.InnerText = "Error: " + ex.Message;
            }
        }
        return success;
    }
    public void BindGridView()
    {
        string query = "SELECT ID,UserName, UserEmail, UserRole, UserID FROM Admin";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString))
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.InnerText = "Error: " + ex.Message;
            }
        }
    }
 
    private void DeleteUser(int userID)
    {
        string connStr = ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "DELETE FROM Admin WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to save updated user details
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "UPDATE Admin SET UserName=@UserName, UserRole=@UserRole, UserEmail=@UserEmail, UserID=@UserID WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
                cmd.Parameters.AddWithValue("@UserName", txtName.Text);
                cmd.Parameters.AddWithValue("@UserRole", ddlUserRole.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@UserEmail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        BindGridView(); // Reload GridView
    }



    protected void gvUsers_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "EditUser")
        {
            // Get the row index properly
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;

            if (row != null)
            {
                

                txtName.Text = row.Cells[1].Text;
                ddlUserRole.SelectedItem.Text = row.Cells[2].Text;
                txtEmail.Text = row.Cells[3].Text;
                txtUserID.Text = row.Cells[4].Text;
            }
        }
        else if (e.CommandName == "DeleteUser")
        {
            int userID = Convert.ToInt32(e.CommandArgument);
            DeleteUser(userID);
            BindGridView();  // Reload the GridView
        }

    }
    
}