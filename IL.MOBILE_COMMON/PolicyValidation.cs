using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class PolicyValidation
    {
        public string ClaimID { get; set; }
        public string PrescriptionID { get; set; }
        public decimal BillAmount { get; set; }
        public decimal PayerPayable { get; set; }
        public decimal PatientPayable { get; set; }
        public decimal EligibleAmt { get; set; }
        public decimal CoPay { get; set; }
        public string CoPayOn { get; set; }
        public String CoPayRelation { get; set; }
        public string MaxCoPay { get; set; }
        public List<polval> ValDet { get; set; }
        public List<PayerPayableBreakUp> PPBreakUp { get; set; }
        public string ValidationResult { get; set; }
        public string order_id { get; set; }
        public string OTP { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public ValidationSummary validationDataTable { get; set; }
        public TranSummary tranDataTable { get; set; }
        public string MemberId { get; set; }
        public string Payer_Code { get; set; }
        public int TransactionTimeOut { get; set; }

    }

    public class polval
    {
        public string valName { get; set; }
        public string valMsg { get; set; }
    }

    public class PayerPayableBreakUp
    {
        public string ValLabel { get; set; }
        public decimal Value { get; set; }
    }

    public class PaymentBreakupDetails
    {
        public string CLAIM_ID { get; set; }
        public int Transcation_Type { get; set; }
        public decimal Bill_Amt { get; set; }
        public decimal PatientPay_Amt { get; set; }
        public decimal PayerPay_Amt { get; set; }
        public decimal Service_charge { get; set; }
        public int PolicyID { get; set; }
        public string ProductName { get; set; }
        public string PolicyStartDate { get; set; }
        public string PolicyEndDate { get; set; }
        public decimal PolicySI { get; set; }
        public decimal PolicyBSI { get; set; }
        public string PolicyNo { get; set; }
        public string MemberName { get; set; }
        public string MemberId { get; set; }
        public string EntityName { get; set; }
        public string EntityCode { get; set; }
        public string OrderID { get; set; }
        public string OneMgOrderId { get; set; }
        public List<PolicyValDetails> PolValDet { get; set; }
        public List<IncluExcluDetails> IncExcDet { get; set; }
        public List<CappingDetails> CappingDet { get; set; }
        public List<CopayDetails> CopayDet { get; set; }
        public List<ItemDetails> lstItem { get; set; }
        public int HideCntInsured { get; set; }
        public int HideTariff { get; set; }
        public string PayerOrderID { get; set; }
    }


    public class OTPIntegrationDetails
    {
        public string OTP_VALUE { get; set; }
        public string EntityCode { get; set; }
        public string PatientPayable { get; set; }
        public string PatientMobileNo { get; set; }
        public string AppointmentID { get; set; }
        public string patient_id { get; set; }
        



    }

    public class PolicyValDetails
    {
        public string Message { get; set; }
        public string Value { get; set; }
        public string transaction_type { get; set; }
        public string value_desc { get; set; }
        public string Message_type { get; set; }
    }

    public class IncluExcluDetails
    {
        public string Message { get; set; }
    }

    public class CappingDetails
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class CopayDetails
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ItemDetails
    {
        public string Item { get; set; }
        public string ItemCode { get; set; }
        public string Value { get; set; }
    }
    public class PolicyValdation_App
    {
        public string PRESCRIPTION_ID { get; set; }
        public string CONSUTATION_NO { get; set; }
        public string MEMBER_ID { get; set; }
        public string SUBMIT_DATE { get; set; }
        public string AILMENT_CODE { get; set; }
        public decimal CONSULTATION_FEE { get; set; }
        public int VALIDATIONTYPE { get; set; }
    }

    public class DataSetValidationTran
    {
        public ValidationSummary validationDataTable { get; set; }

        public TranSummary tranDataTable { get; set; }
    }

    public class ValidationSummary
    {
        public string CLAIM_ID { get; set; }
        public string REMARKS { get; set; }
        public string GROUP_ID { get; set; }
        public string ERROR_FLAG { get; set; }
        public string VALIDATION_NAME { get; set; }
        public string VALIDATION_LABEL { get; set; }
        public string VALIDATION_MESSAGE { get; set; }
        public string TARIFF_AMOUNT { get; set; }
        public string ELIGIBLE_AMOUNT { get; set; }
        public string DISALLOWED_AMOUNT { get; set; }
        public string PAYABLE_AMOUNT { get; set; }
        public string INFO_FLAG { get; set; }
        public string DISPLAY_FLAG { get; set; }
        public string BILL_ITEM_ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string VALIDATION_MESSAGE_1 { get; set; }
        public string VALIDATION_MESSAGE_2 { get; set; }
        public string NO_CO_PAY { get; set; }
        public string COPAY_AMOUNT { get; set; }
        public string COPAY_TYPE { get; set; }
        public string DISPLAY_ORDER { get; set; }
        public string ORDER_ID { get; set; }
        public string PAYMENT_ID { get; set; }
    }

    public class TranSummary
    {
        public string CLAIM_ID { get; set; }
        public string PRODUCT_COPAY { get; set; }
        public string COPAY_TYPE { get; set; }
        public string TOTAL_COPAY_AMOUNT { get; set; }
        public string TOTAL_BILL_AMOUNT { get; set; }
        public string TOTAL_ELIGIBLE_AMOUNT { get; set; }
        public string TOTAL_APPROVED_AMOUNT { get; set; }
        public string TOTAL_PATIENT_PAYABLE { get; set; }
        public string MOBILE_NO { get; set; }
        public string TOTAL_PAYABLE { get; set; }
        public string EMAIL_ID { get; set; }
        public string MEMBER_FIRST_NAME { get; set; }
        public string MEMBER_LAST_NAME { get; set; }
        public string MEMBER_MIDDLE_NAME { get; set; }
        public string PAYER_CODE { get; set; }
        public string POLICY_NO { get; set; }
    }

    public class ValidationSummary1
    {
        public string CLAIM_ID { get; set; }
        public string REMARKS { get; set; }
        public int GROUP_ID { get; set; }
        public string ERROR_FLAG { get; set; }
        public string VALIDATION_NAME { get; set; }
        public string VALIDATION_LABEL { get; set; }
        public string VALIDATION_MESSAGE { get; set; }
        public double TARIFF_AMOUNT { get; set; }
        public double ELIGIBLE_AMOUNT { get; set; }
        public double DISALLOWED_AMOUNT { get; set; }
        public double PAYABLE_AMOUNT { get; set; }
        public string INFO_FLAG { get; set; }
        public string DISPLAY_FLAG { get; set; }
        public int BILL_ITEM_ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string VALIDATION_MESSAGE_1 { get; set; }
        public string VALIDATION_MESSAGE_2 { get; set; }
        public string NO_CO_PAY { get; set; }
        public double COPAY_AMOUNT { get; set; }
        public string COPAY_TYPE { get; set; }
        public string DISPLAY_ORDER { get; set; }
        public decimal ORDER_ID { get; set; }
        public int PAYMENT_ID { get; set; }
    }

    public class TranSummary1
    {
        public string CLAIM_ID { get; set; }
        public double PRODUCT_COPAY { get; set; }
        public string COPAY_TYPE { get; set; }
        public double TOTAL_COPAY_AMOUNT { get; set; }
        public double TOTAL_BILL_AMOUNT { get; set; }
        public double TOTAL_ELIGIBLE_AMOUNT { get; set; }
        public double TOTAL_APPROVED_AMOUNT { get; set; }
        public double TOTAL_PATIENT_PAYABLE { get; set; }
        public string MOBILE_NO { get; set; }
        public double TOTAL_PAYABLE { get; set; }
        public string EMAIL_ID { get; set; }
        public string MEMBER_FIRST_NAME { get; set; }
        public string MEMBER_LAST_NAME { get; set; }
        public string MEMBER_MIDDLE_NAME { get; set; }
        public string PAYER_CODE { get; set; }
        public string POLICY_NO { get; set; }
    }

    public class ItemList
    {
        public string transactionType { get; set; }
        public string ProviderCode { get; set; }
        public string IsHC { get; set; }
        public List<ItemDetails> lstItem { get; set; }
    }
}
