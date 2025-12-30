using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PresNo { get; set; }
        public string PaymentDate { get; set; }
        public string PatientName { get; set; }
        public string PhysicianName { get; set; }
        public string OrderNo { get; set; }
        public string PharmacyName { get; set; }
        public List<PayerPayableBreakUp> PaymentList { get; set; }
        public List<PayerPayableBreakUp> PayerPayableBreakUp { get; set; }
        public string PaymentReceipt { get; set; }
        public decimal BillAmount { get; set; }
        public decimal PayerPayable { get; set; }
        public decimal PatientPayable { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public int Payment_Type { get; set; }
        public int Payment_Status { get; set; }
        public int Transaction_type { get; set; }
        public int User_Id { get; set; }
        public string Payment_GUID { get; set; }
        public string Member_Id { get; set; }
        public string Payer_code { get; set; }
    }

    public class Phy_Pay_DashBoard
    {
        public string PayerName { get; set; }
        public string PaymentAmt { get; set; }
        public int Paid { get; set; }
    }

    public class OP_Pay_DashBoard
    {
        public int PayerId { get; set; }
        public string PayerCode { get; set; }
        public string PayerName { get; set; }
        public string PaymentAmt { get; set; }
        public int Paid { get; set; }
        public string BillAmt { get; set; }
        public string PaidAmt { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
       
    }

    public class PaymentList
    {
        public string prescriptionId { get; set; } 
        public decimal BillAmt { get; set; }
        public decimal TotalBillAmt { get; set; }
        public decimal PayerPayable { get; set; }
        public decimal PatientPayable { get; set; }
        public List<Payment> lstPayment { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class PaymentDetailForService
    {
        public string Payment_Date { get; set; }
        public string Payment_Narration { get; set; }
        public string Payment_Amt { get; set; }
        public string Payer_Cheque_Refno { get; set; }
        public Int32 Paid { get; set; }
        public string Prescription_Id { get; set; }
        public string Patient_name { get; set; }
        public string OrderId { get; set; }
        public string ApprovedDate { get; set; }
        public string PaidDate { get; set; }
        public string NeftNumber { get; set; }
        public string TDS { get; set; }
        public string Status { get; set; }
        public string SettlementLetter { get; set; }
    }
}
