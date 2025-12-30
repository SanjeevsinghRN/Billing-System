<%@ Page Title="Purchase Order Entry" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="ItemEntry.aspx.cs" Inherits="Modules_ItemEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
        }

        .container {
            width: 95%;
            max-width: 1200px;
            margin: auto;
            background: #fff;
            padding: 20px;
            box-shadow: 0px 0px 10px #aaa;
            border-radius: 8px;
        }

        .header {
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 15px;
            color: purple;
        }

        .tabs {
            display: flex;
            justify-content: start;
            margin-bottom: 15px;
        }

        .tab {
            padding: 10px 20px;
            cursor: pointer;
            background: #ddd;
            margin-right: 5px;
            border-radius: 5px 5px 0 0;
        }

        .tab.active {
            background: purple;
            color: #fff;
        }

        .tab-content {
            display: none;
            padding: 20px;
            border: 1px solid #ccc;
            background: #fff;
        }

        .tab-content.active {
            display: block;
        }

        .form-group {
            display: flex;
            justify-content: space-between;
            margin-bottom: 10px;
        }

        .form-group label {
            flex: 1;
            text-align: right;
            margin-right: 10px;
            font-weight: bold;
        }

        .form-group input {
            flex: 2;
            padding: 5px;
        }

        .grid-container {
            width: 100%;
            overflow-x: auto;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid #ccc;
            text-align: center;
            padding: 8px;
        }

        th {
            background: #ddd;
        }

        .action-buttons {
            display: flex;
            justify-content: center;
            gap: 10px;
        }

        .bottom-section {
            margin-top: 20px;
            border-top: 2px solid #ccc;
            padding-top: 10px;
        }
    </style>

    <script>
        function showTab(tabIndex) {
            document.querySelectorAll('.tab').forEach((tab, index) => {
                tab.classList.toggle('active', index === tabIndex);
                document.querySelectorAll('.tab-content')[index].classList.toggle('active', index === tabIndex);
            });

            // 🔹 If switching to 2nd tab, refresh GridView
            if (tabIndex === 1) {
                __doPostBack('<%= gvItems.ClientID %>', '');
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="header">Purchase Order Entry</div>
        <div class="tabs">
            <div class="tab active" onclick="showTab(0)">PO Entry</div>
            <div class="tab" onclick="showTab(1)">Browse PO</div>
        </div>

        <!-- 🔹 First Tab: PO Entry -->
        <div class="tab-content active">
            <div class="form-group">
                <label>PO No.:</label>
                <asp:TextBox ID="txtPONo" runat="server"></asp:TextBox>
                <label>PO Date:</label>
                <asp:TextBox ID="txtPODate" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Distributor Code:</label>
                <asp:TextBox ID="txtDistributorCode" runat="server"></asp:TextBox>
                <label>Vendor Salesman Name:</label>
                <asp:TextBox ID="txtVendorSalesman" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Employee Code:</label>
                <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox>
                <label>Payment Terms:</label>
                <asp:TextBox ID="txtPaymentTerms" runat="server"></asp:TextBox>
            </div>

            <!-- 🔹 GridView is now inside the first tab -->
            <div class="grid-container">
                <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" CssClass="table1">
                    <Columns>
                        <asp:BoundField DataField="BarCode" HeaderText="Bar Code" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="SchemeQty" HeaderText="Scheme Qty" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                        <asp:BoundField DataField="Value" HeaderText="Value" />
                        <asp:BoundField DataField="MRP" HeaderText="MRP" />
                        <asp:BoundField DataField="GST" HeaderText="GST%" />
                        <asp:BoundField DataField="SaleRate" HeaderText="Sale Rate" />
                        <asp:BoundField DataField="ProfMargin" HeaderText="Prof Margin Down %" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- 🔹 Second Tab: Browse PO -->
        <div class="tab-content">
            <p>Browse purchase orders here...</p>
        </div>

        <div class="bottom-section">
            <div class="form-group">
                <label>Extra Discount:</label>
                <asp:TextBox ID="txtExtraDiscount" runat="server"></asp:TextBox>
                <label>Taxable Amount:</label>
                <asp:TextBox ID="txtTaxableAmount" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>GST Amount:</label>
                <asp:TextBox ID="txtGSTAmount" runat="server"></asp:TextBox>
                <label>Total Amount:</label>
                <asp:TextBox ID="txtTotalAmount" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
