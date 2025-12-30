<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterMenu.master" AutoEventWireup="true" CodeFile="Dashboard_Emp.aspx.cs" Inherits="Modules_Dashboard_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/masterMenu.js"></script>
    <script src="../New_ui/js/main.js"></script>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>

    <title>SKS Project Pvt Ltd.</title>
    <%-- <link href="../New_ui/css/style.css" rel="stylesheet" />--%>
    <style>
        .footer {
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
    background-color: #f8f9fa;
    box-shadow: 0 -2px 5px rgba(0, 0, 0, 0.1);
    padding: 10px 0;
    display: flex;
    justify-content: center;
    align-items: center;
    background:#5A5870;
}
        .page-item td, .page-item th {
    text-align: right; /* Right-align footer and data cells */
}

.page-item th:first-child, .page-item td:first-child {
    text-align: left; /* Left-align the first column (Item Name) */
}
        @media(max-width:768px) {
            .sidebaar {
                position: static;
                height: auto;
            }

            .top-navbar {
                position: static;
            }
        }

        .page-item th {
            background-color: #5A5870;
            color: white;
            position: sticky; /* Makes the header fixed */
            top: 0;
            z-index: 2;
        }

        .scroll-container {
            overflow-x: auto; /* Enables horizontal scrolling */
            overflow-y: hidden; /* Prevents vertical scrolling */
            white-space: nowrap; /* Prevents wrapping of content */
        }



        /* Style for the GridView rows */
        .page-item tr:hover {
            background: linear-gradient(135deg, #5A5870, #75738A); /* Blue background on hover */
            color: white; /* White text on hover */
            cursor: pointer; /* Pointer cursor on hover */
            box-shadow: 0 4px 8px rgb(83, 42, 133); /* Blue shadow effect */
            transition: all 0.3s ease; /* Smooth transition effect */
        }


        .page-item td {
            transition: background-color 0.3s, color 0.3s;
        }

        .custom-button {
            height: 32px;
            background-color: #3D4C56;
            color: white;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
            font-size: 14px;
            border-radius: 5px;
            transition: background-color 0.3s, color 0.3s;
            box-shadow: 0 4px 8px rgb(83, 42, 133); /* Blue shadow effect */
            transition: all 0.3s ease;
        }

            .custom-button:hover {
                background-color: #4f3f8f; /* Darker blue on hover */
            }

        .bordered-grid {
            border-collapse: collapse;
            width: 100%;
        }

        .bordered-cell {
            border-top: 1px; /* Row border at the top */
            border-bottom: 1px medium; /* Row border at the bottom */
            border-left: none; /* Remove left border */
            border-right: none; /* Remove right border */
            padding: 8px;
            text-align: center;
        }

        .search {
            display: flex;
            align-items: center;
            gap: 10px; /* Space between textbox and button */
        }

        .search-box {
            width: 500px; /* Adjust width as needed */
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

         .Mobileinout {
            width: 250px; /* Adjust width as needed */
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }


        .search-button {
            padding: 8px 12px;
            font-size: 14px;
            background-color: #2a2185; /* Blue */
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            .search-button:hover {
                background-color: #3b3295; /* Lighter blue */
            }

        .divGridView {
           
            max-height:380px;
            overflow-y: auto;
            overflow-x: hidden;
            /* Optional: Adds border */
        }

        .divGridView1 {
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            width: 100%;
            color:white;
            background:#5A5870;
        }

        .scroll-container1 {
            display: flex;
           /* overflow-x: hidden;  Hide scrollbar */
            scroll-behavior: smooth;
            width: 99%;  
           
            
            padding: 5px;
            white-space: nowrap;
            max-height:100px;
        }

      /*scroll-item {
    display: flex;
    flex-direction: column;*/ /* Stack image and text vertically */
    /*align-items: center;*/ /* Center the text below image */
    /*text-align: center;
    margin: 10px;*/ /* Adjust spacing if needed */
/*}*/

/*.scroll-item-img {
    width: 100px;*/ /* Adjust image size */
    /*height: 100px;
    object-fit: cover;*/ /* Ensure proper image fit */
    /*border-radius: 8px;*/ /* Optional for rounded corners */
/*}*/

/*.category-name {
    margin-top: 5px;*/ /* Space between image and text */
    /*font-size: 14px;
    font-weight: bold;
    color: #333;*/ /* Adjust color */
/*}*/

        .scroll-btn {
            background-color: #75738A;
            color: white;
            border: none;
            padding: 10px 15px;
            cursor: pointer;
            font-size: 20px;
            border-radius: 5px;
        }

            .scroll-btn:hover {
                background: #75738A;
            }

        /*.scroll-item {
            min-width: 100px;*/ /* Width of each item */
            /*height: 100px;*/ /* Height of each item */
            /*background-color: lightblue;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 18px;
            font-weight: bold;
            border-radius: 10px;
            margin:5px;
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
            overflow: hidden;*/ /* To ensure the image doesn't overflow the container */
        /*}*/

        /*.scroll-item-img {
            width: 100%;*/ /* Make image fill the container */
            /*height: 100%;*/ /* Ensure image fits within the scroll item */
            /*object-fit: cover;*/ /* Ensure the image is properly cropped */
        /*}*/
        /* Highlight rows with border and different background */
.highlight-row {
    background-color: #f8f9fa !important; /* Light grey background */
    border: 2px solid #007bff !important; /* Blue border */
}

/* Bold text for highlighted rows */
.highlight-row td {
    font-weight: bold !important;
    color: #333; /* Dark text for better visibility */
}

/*
.scroll-container1 {
    display: flex;
    overflow-x: auto;
    scroll-behavior: smooth;
    padding: 10px;
}*/

/*.scroll-item {
    text-align: center;
    margin: 0 10px;
    cursor: pointer;
}*/

/*.scroll-item-img {
    width: 80px;
    height: 80px;
    object-fit: cover;
    border-radius: 8px;
    transition: transform 0.2s;
}*/

.scroll-item-img:hover {
    transform: scale(1.1);
}

/*.category-name {
    font-size: 14px;
    margin-top: 5px;
    color: #333;
    font-weight: bold;
}
*/
/* Modal Styling */
.modal {
    display: none; /* Ensure it is hidden initially */
    position: fixed;
    z-index: 1000;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.6);
    align-items: center;
    justify-content: center;
}

.modal-content {
    background: white;
    padding: 20px;
    border-radius: 10px;
    width: 50%;
    text-align: center;
}

.modal-items {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}

.modal-item {
    margin: 10px;
    text-align: center;
}

.modal-item img {
    width: 80px;
    height: 80px;
    object-fit: cover;
    border-radius: 8px;
}

.close-btn {
    position: absolute;
    right: 20px;
    top: 10px;
    font-size: 20px;
    cursor: pointer;
}
/*.scroll-container1 {
    display: flex;
    flex-wrap: nowrap;
    overflow-x: auto;
    gap: 10px;*/ /* Adjust spacing between items */
/*}*/

.scroll-item {
    display: flex;
    flex-direction: column; /* Stack image and text vertically */
    align-items: center; /* Center the text below image */
    text-align: center;
    width: 120px; /* Adjust based on your requirement */
    max-height:80px;
}

.scroll-item-img {
    width: 75px; /* Adjust image size */
    height: 75px;
    object-fit: cover; /* Ensure image is properly cropped */
    border-radius: 8px; /* Optional for rounded corners */
}

.category-name {
    margin-top: 5px; /* Space between image and text */
    font-size: 14px;
    font-weight: bold;
    color:white; /* Adjust color */
    width: 100%; /* Ensure it aligns properly */
    text-align: center; /* Center the text */
}



    </style>
    <script type="text/javascript">


        $(document).ready(function () {
            $('#GridView1').gridviewScroll({
                width: 600,
                height: 300,
                freezesize: 2, // Freeze Number of Columns.
                headerrowcount: 1, //Freeze Number of Rows with Header.
                arrowsize: 30,
                varrowtopimg: "Images/arrowvt.png",
                varrowbottomimg: "Images/arrowvb.png",
                harrowleftimg: "Images/arrowhl.png",
                harrowrightimg: "Images/arrowhr.png"
            });
        });
    </script>
    <script type="text/javascript">
        function scrollLeft(event) {
            event.preventDefault(); // Prevent button from triggering form submission
            let container = document.querySelector(".scroll-container1");
            container.scrollBy({ left: -200, behavior: "smooth" });
        }

        function scrollRight(event) {
            event.preventDefault(); // Prevent button from triggering form submission
            let container = document.querySelector(".scroll-container1");
            container.scrollBy({ left: 200, behavior: "smooth" });
        }
        const categoryItems = {
            Grocery: [
                { name: "Milk", img: "../Images/Loyal/milk.jpg" },
                { name: "Pineapple", img: "../Images/Loyal/Pineapple.png" }
            ],
            Beverages: [
                { name: "Coca Cola", img: "../Images/Loyal/Cocacola.jpg" },
                { name: "Kinley Water", img: "../Images/Loyal/Kinley.jpg" }
            ],
            Snacks: [
                { name: "Dairy Milk", img: "../Images/Loyal/Dairy-milk.jpg" },
                { name: "Salted Pista", img: "../Images/Loyal/pista-salted.jpg" }
            ],
            Fruits: [
                { name: "Mango", img: "../Images/Loyal/Mango.jpg" },
                { name: "Watermelon", img: "../Images/Loyal/watermelon.jpg" }
            ]
        };

        function openModal(category) {
            const modal = document.getElementById("categoryModal");

            // Ensure modal is only shown when a category is clicked
            if (!category) return;

            const modalTitle = document.getElementById("modal-title");
            const modalItems = document.getElementById("modal-items");

            modalTitle.innerText = category + " Items";
            modalItems.innerHTML = "";

            categoryItems[category].forEach(item => {
                const itemDiv = document.createElement("div");
                itemDiv.classList.add("modal-item");
                itemDiv.innerHTML = `<img src="${item.img}" alt="${item.name}"><p>${item.name}</p>`;
                modalItems.appendChild(itemDiv);
            });

            modal.style.display = "flex"; // Ensure flex is only applied when opening the modal
        }

        // Function to close the modal
        function closeModal() {
            document.getElementById("categoryModal").style.display = "none";
        }

        // Ensure the modal closes when clicking outside of it
        window.onclick = function (event) {
            const modal = document.getElementById("categoryModal");
            if (event.target === modal) {
                closeModal();
            }
        };


        function closeModal() {
            document.getElementById("categoryModal").style.display = "none";
        }

        //function scrollLeft(event) {
        //    const container = event.target.nextElementSibling;
        //    container.scrollBy({ left: -100, behavior: 'smooth' });
        //}

        //function scrollRight(event) {
        //    const container = event.target.previousElementSibling;
        //    container.scrollBy({ left: 100, behavior: 'smooth' });
        //}
       
            function printBill() {
        var billContent = document.getElementById("billSection").innerHTML;
            var printWindow = window.open('', '', 'width=800,height=600');
            printWindow.document.write('<html><head><title>Invoice</title>');
                printWindow.document.write('<style>body{font - family: Arial, sans-serif;}</style>'); // Add CSS
                printWindow.document.write('</head><body>');
                    printWindow.document.write(billContent);
                    printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
    }


    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
     
        <div class="main">

            <div class="container">
                <div class="row">
                   
                    <div class="col-lg-8 col-md-6 col-12">
                        <div class="recentCustomers">
                            <div class="cardHeader">
                                <h2>Recent Orders</h2>
                            </div>
                             <div class="search">
                                 <asp:Label ID="lblMobono" runat="server" Text="Customer Mobile No :"></asp:Label>
                                <asp:TextBox ID="txtmobno" runat="server" CssClass="Mobileinout" placeholder="Search here"></asp:TextBox>
                                <asp:Button ID="btnAddmob" OnClick="btnAddmob_Click" runat="server" Text="Add" CssClass="btn btn-success" />
                            </div>
                            <div class="divGridView">
                <asp:GridView ID="gvOrder_List" runat="server" Width="100%" RowStyle-HorizontalAlign="Center"
    AutoGenerateColumns="false" DataKeyNames="Item_Desc,Sale_Rate,Def_Qty"
    OnRowCommand="gvOrder_List_RowCommand" OnRowDataBound="gvOrder_List_RowDataBound"
    GridLines="None" CssClass="page-item bordered-grid" ShowFooter="true">
    <Columns>
        <asp:BoundField DataField="Item_Desc" HeaderText="ITEM NAME" ItemStyle-HorizontalAlign="Left" />
        
        <asp:BoundField DataField="Sale_Rate" HeaderText="PRICE" ItemStyle-HorizontalAlign="Right" />
        
        <asp:TemplateField HeaderText="QUANTITY" HeaderStyle-CssClass="Name bordered-cell" ItemStyle-CssClass="Name bordered-cell">
            <ItemTemplate>
               <asp:Button ID="btnDecrease" runat="server" Text="-" CssClass="custom-button"
    CommandName="DecreaseQuantity" CommandArgument='<%# Container.DisplayIndex %>' />

<asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Def_Qty") %>' CssClass="quantity-label"></asp:Label>

<asp:Button ID="btnIncrease" runat="server" Text="+" CssClass="custom-button"
    CommandName="IncreaseQuantity" CommandArgument='<%# Container.DisplayIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Total Price" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <%# Eval("Sale_Rate") != null && Eval("Def_Qty") != null ? 
                    Convert.ToDecimal(Eval("Sale_Rate")) * Convert.ToInt32(Eval("Def_Qty")) : 0 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField HeaderText="GST (18%)" ItemStyle-HorizontalAlign="Right" />

        <asp:BoundField HeaderText="Grand Total" ItemStyle-HorizontalAlign="Right" />
    </Columns>
    <FooterStyle HorizontalAlign="Right" />
</asp:GridView>

                                
                                
                            </div>
                            
                               

                        </div>
                         <div class="text-center mt-3">
    <asp:Button ID="btnProceedToPayment" runat="server" CssClass="btn btn-success"
        Text="Proceed to Payment" OnClick="btnProceedToPayment_Click" Visible="false" />
</div>
                    </div>

                    <!-- Recent Customers -->
                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="recentCustomers">
                            <div class="cardHeader">
                                <h2>Recent Customers</h2>
                            </div>
                            <div class="search">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="search-box" placeholder="Search here"></asp:TextBox>
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" CssClass="btn btn-success" />
                            </div>
                            <div class="divGridView">
                                <asp:GridView ID="gvItem_list" runat="server" Width="100%" RowStyle-HorizontalAlign="Center"
                                    AutoGenerateColumns="false" DataKeyNames="Item_Desc,Sale_Rate" OnRowCommand="gvItem_list_RowCommand"
                                    GridLines="None" CssClass="page-item bordered-grid">
                                   <Columns>
       
        <asp:TemplateField HeaderText="Sr.#">
            <HeaderStyle CssClass="bordered-cell" />
            <ItemStyle CssClass="bordered-cell" />
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

      
        <asp:BoundField DataField="Item_Code" HeaderText="CODE" Visible="false">
            <HeaderStyle CssClass="bordered-cell" />
            <ItemStyle CssClass="bordered-cell" />
        </asp:BoundField>

       
        <asp:BoundField DataField="Item_Desc" HeaderText="ITEM NAME">
            <HeaderStyle CssClass="bordered-cell" />
            <ItemStyle CssClass="bordered-cell" />
        </asp:BoundField>

      
        <asp:BoundField DataField="Sale_Rate" HeaderText="MRP">
            <HeaderStyle CssClass="bordered-cell" />
            <ItemStyle CssClass="bordered-cell" />
        </asp:BoundField>

      
        <asp:TemplateField HeaderText="Add To Cart">
            <HeaderStyle CssClass="bordered-cell" />
            <ItemStyle CssClass="bordered-cell" />
            <ItemTemplate>
                <asp:Button ID="btnAdd" runat="server" Text="Add Item" CssClass="btn btn-success"
                    CommandName="AddItem" CommandArgument='<%# Eval("Item_Desc") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <footer class="footer">
    <div class="divGridView1">
        <button class="scroll-btn left" onclick="scrollLeft(event)">&#9665;</button>
        <div class="scroll-container1">
            <div class="scroll-item" onclick="openModal('Grocery')">
                <img src="../Images/Loyal/milk.jpg" alt="Milk" class="scroll-item-img" />
                <p class="category-name">Grocery</p>
            </div>
            <div class="scroll-item" onclick="openModal('Beverages')">
                <img src="../Images/Loyal/Cocacola.jpg" alt="Coca Cola" class="scroll-item-img" />
                <p class="category-name">Beverages</p>
            </div>
            <div class="scroll-item" onclick="openModal('Snacks')">
                <img src="../Images/Loyal/Dairy-milk.jpg" alt="Dairy Milk" class="scroll-item-img" />
                <p class="category-name">Snacks</p>
            </div>
            <div class="scroll-item" onclick="openModal('Fruits')">
                <img src="../Images/Loyal/Mango.jpg" alt="Mango" class="scroll-item-img" />
                <p class="category-name">Fruits</p>
            </div>
            <div class="scroll-item">
    <img src="../Images/Loyal/Kinley.jpg" alt="Item 1" class="scroll-item-img" />
    <p class="category-name">Beverages</p> <!-- Category Name -->
</div>
        </div>
        <button class="scroll-btn right" onclick="scrollRight(event)">&#9655;</button>
    </div>
</footer>
<!-- Modal -->
<div id="categoryModal" class="modal">
    <div class="modal-content">
        <span class="close-btn" onclick="closeModal()">&times;</span>
        <h2 id="modal-title">Category Items</h2>
        <div id="modal-items" class="modal-items"></div>
    </div>
</div>
        

    </div>
        </div>

</asp:Content>

 <%--    <footer class="footer">
    <div class="divGridView1">
        <button class="scroll-btn left" onclick="scrollLeft(event)">&#9665;</button>
        <div class="scroll-container1">
            <div class="scroll-item">
                <img src="../Images/Loyal/Kinley.jpg" alt="Item 1" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/Cocacola.jpg" alt="Item 2" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/pista-salted.jpg" alt="Item 3" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/Pineapple.png" alt="Item 4" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/Dairy-milk.jpg" alt="Item 5" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/mirch.jpg" alt="Item 6" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/milk.jpg" alt="Item 7" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/Mango.jpg" alt="Item 8" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/watermelon.jpg" alt="Item 9" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/handwash.jpg" alt="Item 10" class="scroll-item-img" />
            </div>
            <div class="scroll-item">
                <img src="../Images/Loyal/surfexcel.png" alt="Item 11" class="scroll-item-img" />
            </div>
             <div class="scroll-item">
                <img src="../Images/Loyal/surfexcel.png" alt="Item 11" class="scroll-item-img" />
            </div>
             <div class="scroll-item">
                <img src="../Images/Loyal/surfexcel.png" alt="Item 11" class="scroll-item-img" />
            </div>
             <div class="scroll-item">
                <img src="../Images/Loyal/surfexcel.png" alt="Item 11" class="scroll-item-img" />
            </div>
        </div>
        <button class="scroll-btn right" onclick="scrollRight(event)">&#9655;</button>
    </div>
</footer>--%>
