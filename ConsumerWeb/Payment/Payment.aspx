<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .center-container {
            display: flex;
            justify-content: center; /* Center horizontally */
            align-items: center; /* Center vertically */
            height: 100vh; /* Full screen height */
        }
        .qr-box {
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="center-container">
        <asp:Panel ID="pnlQRCode" runat="server" CssClass="qr-box" Visible="false">
            <h3>Scan & Pay via PhonePe</h3>
            <img src="../Images/Loyal/phonepayqr.jpeg" alt="PhonePe QR Code" style="width: 250px; height: 250px;" />
            <p>Scan this QR code using PhonePe, Google Pay, or any UPI app.</p>
            <asp:Button ID="btnPaymentDone" runat="server" CssClass="btn btn-primary mt-3"
                Text="I have completed the payment" OnClick="btnPaymentDone_Click" />
        </asp:Panel>
    </div>
</asp:Content>
