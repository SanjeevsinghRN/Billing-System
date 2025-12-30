<%@ Page Title="Order Summary" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="OrderSummary.aspx.cs" Inherits="OrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        .order-summary-container {
            margin-top: 10px; /* Push content down to avoid overlap */
            padding: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="order-summary-container text-center mt-4">
        <h3>Order Summary</h3>
        <p>Thank you for your payment!</p>
        <hr>

        <p><strong>Bill No:</strong> <asp:Label ID="lblBillNo" runat="server" /></p>
        <p><strong>Order Date:</strong> <asp:Label ID="lblOrderDate" runat="server" /></p>
        <p><strong>Total Amount:</strong> ₹<asp:Label ID="lblTotalAmount" runat="server" /></p>
        <p><strong>Payment Mode:</strong> UPI (PhonePe)</p>
        <hr>

        <h4>Purchased Items</h4>
        <asp:GridView ID="gvPurchasedItems" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="Item" />
                <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>
        </asp:GridView>

        <hr>
        <asp:Button ID="btnGoHome" runat="server" CssClass="btn btn-success" Text="Go to Homepage" OnClick="btnGoHome_Click" />
    </div>
</asp:Content>
