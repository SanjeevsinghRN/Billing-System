using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Oderdetails
    {
        public string order_id { get; set; }
        public string prescription_id { get; set; }
        public string address { get; set; }
        public string pin { get; set; }
        public string mobile_no { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string orderdate { get; set; }
        public string pharmacyname { get; set; }
        public string diagnosticname { get; set; }
        public string Order_Amt { get; set; }
        public string OrderTime { get; set; }
        public DateTime? ORDER_DATE { get; set; }
        public string order_type { get; set; }

        public string OrderStatus { get; set; }
        public string PayerOrderId { get; set; }

        public string EntityCode { get; set; }

        public string OrderStatusID { get; set; }
        public string ConsignmentNo { get; set; }
        public string DeliveryPartner { get; set; }
        public string PayerRemarks { get; set; }
        public string DeliveryNote { get; set; }
        public string InvoiceNo { get; set; }
        [Ignore]
        public List<OrderItemDetails> lstOrderItem { get; set; }

        public string TransactionType { get; set; }
        public Int32 Is_health_check { get; set; }

        public Int32 hasFeedback { get; set; }

        public string OrderStausDate { get; set; }
        public string CS_Number { get; set; }
        public string Aggregator_Type { get; set; }
        public string pharmacyType { get; set; }
        public string isOnlineFlow { get; set; }
        public string OTP_VALUE { get; set; }
        public List<PaymentDetails> lstPaymentDet { get; set; }
        
    }


    public class PaymentDetails
    {
        public string Order_Id { get; set; }
        public string Payment_Type { get; set; }
        public string Payment_Amount { get; set; }
        public string Payment_Date { get; set; }
        public string Payment_Id { get; set; }
        public string Transaction_type { get; set; }
        public string Ext_Payment_Link { get; set; }
        public string Ext_Payment_Status { get; set; }
    }
}
