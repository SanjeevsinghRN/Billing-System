<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="NewUser_Register.aspx.cs" Inherits="Modules_NewUser_Register" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container mt-4">
        <div class="card shadow-lg">
            <div class="card-header bg-primary text-white text-center">
                <h4>Create Employee User ID</h4>
            </div>
            <div class="card-body">
                <!-- Row with all 4 input fields in one line -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label class="form-label">Full Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label">User Role</label>
                        <asp:DropDownList ID="ddlUserRole" Height="35px" CssClass="form-select" runat="server">
                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                            <asp:ListItem Text="Manager" Value="Manager"></asp:ListItem>
                            <asp:ListItem Text="Employee" Value="Employee"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label">Email ID</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label">User ID</label>
                        <asp:TextBox ID="txtUserID" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <!-- Add User Button -->
                <div class="text-center">
                    <asp:Button ID="btnAddUser" OnClick="btnAddUser_Click" runat="server" CssClass="btn btn-success" Text="Add User" />
                </div>
                <label runat="server" id="lblMessage" class="form-label">User ID</label>
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </div>

        <!-- GridView for Displaying Users -->
        <div class="card mt-4">
            <div class="card-header bg-dark text-white text-center">
                <h5>User List</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvUsers" runat="server" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" DataKeyNames="ID"
                    EmptyDataText="No users found." AllowPaging="true" PageSize="5" OnRowCommand="gvUsers_RowCommand1">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Slr no" ReadOnly="True" />
                        <asp:BoundField DataField="UserName" HeaderText="Full Name" />
                        <asp:BoundField DataField="UserRole" HeaderText="User Role" />
                        <asp:BoundField DataField="UserEmail" HeaderText="Email ID" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"
                                    CommandName="EditUser" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                                    CommandName="DeleteUser" CommandArgument='<%# Eval("ID") %>'
                                    OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>


