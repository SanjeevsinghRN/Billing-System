<%@ Page Title="Billing" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="FrmSMBill.aspx.cs" Inherits="Modules_FrmSMBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .form-container {
            width: 100%;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
        }
        .form-row {
            margin-bottom: 10px;
        }
        .form-label {
            width: 150px;
            display: inline-block;
            font-weight: bold;
        }
        .form-control {
            width: 200px;
            padding: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
        <!-- Bill Details -->
        <div class="form-row">
            <asp:Label ID="LblBillNo" runat="server" Text="Bill No:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtBillNo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="BtnBillNoHelp" runat="server" Text="..." OnClick="BtnBillNoHelp_Click" />
        </div>
        <div class="form-row">
            <asp:Label ID="LblBillDate" runat="server" Text="Bill Date:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtBillDate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="BtnBillDateHelp" runat="server" Text="..." OnClick="BtnBillDateHelp_Click" />
        </div>

        <!-- Customer Details -->
        <div class="form-row">
            <asp:Label ID="LblCustCode" runat="server" Text="Customer Code:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtCustCode" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="BtnCustCodeHelp" runat="server" Text="..." OnClick="BtnCustCodeHelp_Click" />
        </div>
        <div class="form-row">
            <asp:Label ID="LblCustName" runat="server" Text="Customer Name:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtCustName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Order Details -->
        <div class="form-row">
            <asp:Label ID="LblOrderID" runat="server" Text="Order ID:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtOrderID" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="BtnOrderIDHelp" runat="server" Text="..." OnClick="BtnOrderIDHelp_Click" />
        </div>

        <!-- Bill Items Grid -->
        <div class="form-row">
            <asp:GridView ID="GvBillItems" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                </Columns>
            </asp:GridView>
        </div>

        <!-- Buttons -->
        <div class="form-row">
            <asp:Button ID="BtnHoldBill" runat="server" Text="Hold Bill" OnClick="BtnHoldBill_Click" />
            <asp:Button ID="BtnClose" runat="server" Text="Close" OnClick="BtnClose_Click" />
            <asp:Button ID="BtnUploadBill" runat="server" Text="Upload Bill" OnClick="BtnUploadBill_Click" />
        </div>
    </div>
</asp:Content>