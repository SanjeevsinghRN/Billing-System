using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class DR_REDDY
    {
    }
    public class GenericError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class DR_AuthToken_Request
    {
        public string clientKey { get; set; }
        public string clientSecret { get; set; }
        public string tenantId { get; set; }
    }

    public class DR_AuthToken_Response
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
    }

    public class DR_DocSlotRequest
    {
        public string bookingType { get; set; }
        public string branchId { get; set; }
        public string docId { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
    }

    public class DR_DOC_SLOTS_MAIN
    {
        public List<DR_DOC_SLOTS> DR_DOC_SLOTS { get; set; }
        public string Message { get; set; }
    }
    public class DR_DOC_SLOTS
    {
        public string date { get; set; }
        public List<DR_SLOT_TIME> session_1 { get; set; }
        public List<DR_SLOT_TIME> session_2 { get; set; }

    }

    public class DR_SLOT_TIME
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string status { get; set; }

    }

    public class DR_INTEGRATION_DATA
    {
        public string INTEGRATION_ID { get; set; }
        public string INTEGRATION_CODE { get; set; }
        public string PROFILE_CODE { get; set; }
    }


    public class DR_APP_PATD_REQ_B
    {
        public string dob { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string policy_company { get; set; }
        public string policy_id { get; set; }
    }

    public class DR_APP_APPD_REQ_B
    {
        public string appointment_date { get; set; }
        public string appointment_end_time { get; set; }
        public string appointment_status { get; set; }
        public string appointment_time { get; set; }
        public string appointment_type { get; set; }
    }

    public class DR_APP_REQ_B
    {
        public DR_APP_APPD_REQ_B appointment_details { get; set; }
        public string appointment_id { get; set; }
        public string authorization_code { get; set; }
        public string branch_id { get; set; }
        public string doctor_id { get; set; }
        public string elegibility_amount { get; set; }
        public string insurance_company_name { get; set; }
        public string number_of_consultation { get; set; }
        public DR_APP_PATD_REQ_B patient_details { get; set; }
        public string payable_by_user { get; set; }
        public string payable_by_insurance { get; set; }
        public string payable_by_user_GST { get; set; }
        public string uhid { get; set; }
        public string tenant_appointment_id { get; set; }
        public string consultation_amount { get; set; }
    }
    public class DR_APP_ROOT_REQ_B
    {
        public DR_APP_REQ_B data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class DR_APP_APPD_RES_B
    {
        public string appointment_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string appointment_type { get; set; }
    }

    public class DR_APP_DATA2_RES_B
    {
        public string appointment_id { get; set; }
        public string doctor_id { get; set; }
        public string branch_id { get; set; }
        public string policy_id { get; set; }
        public string policy_company { get; set; }
        public string appointment_status { get; set; }
        public DR_APP_APPD_RES_B appointment_details { get; set; }
    }

    public class DR_APP_DATA1_RES_B
    {
        public string success { get; set; }
        public string error { get; set; }
        public DR_APP_DATA2_RES_B data { get; set; }
        public string status_code { get; set; }
    }

    public class DR_APP_ROOT_RES_B
    {
        public int statusCode { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public DR_APP_DATA1_RES_B data { get; set; }
        public string success { get; set; }
        public string error { get; set; }
    }


    public class DR_APP_REQ_R
    {
        public DR_APP_APPD_REQ_B appointment_details { get; set; }
        public string appointment_id { get; set; }
        public string authorization_code { get; set; }
        public string branch_id { get; set; }
        public string doctor_id { get; set; }
        public string insurance_company_name { get; set; }
        public DR_APP_PATD_REQ_B patient_details { get; set; }
    }

    public class DR_APP_ROOT_REQ_R
    {
        public DR_APP_REQ_R data { get; set; }
    }

    public class DR_UpdateAppointment
    {
        public string appointment_date { get; set; }
        public string appointment_status { get; set; }
        public string appointment_type { get; set; }
        public string cancellation_reason { get; set; }
        public string cancelled_by { get; set; }
        public string end_time { get; set; }
        public string start_time { get; set; }
    }

    public class DR_UpdateAppointmentMain
    {
        public DR_UpdateAppointmentMain1 data { get; set; }
    }

    public class DR_ValidateOTPMain
    {
        public DR_ValidateOTP data { get; set; }
    }

    public class DR_ValidateOTP
    {
        public string appointment_id { get; set; }
        public string otp { get; set; }
    }

    public class DRL_PharValidateOtp
    {
        public string order_id { get; set; }
        public string otp { get; set; }
    }
    public class DRL_PharValidateResp
    {
        public string error_code { get; set; }
        public string error_desc { get; set; }
    }

    public class DR_ValidateResp
    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }

    public class DR_UpdateAppointmentMain1
    {
        public DR_UpdateAppointment appointment_details { get; set; }
        public string appointment_id { get; set; }
        public string branch_id { get; set; }
        public string doctor_id { get; set; }
        public string policy_company { get; set; }
        public string policy_id { get; set; }
    }


    public class AppointmentDetails_DRLResponse
    {
        public string appointment_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string appointment_type { get; set; }
    }

    public class PaymentDetail_DRLResponse
    {
        public string resultMessage { get; set; }
        public int linkId { get; set; }
        public string orderId { get; set; }
        public string url { get; set; }
        public string expiryDate { get; set; }
    }



    public class Data_ReRespStatus
    {
        public bool success { get; set; }
        public string error { get; set; }
        public Root_DRLResponse data { get; set; }
        public int status_code { get; set; }
    }

    public class ReApp_DRLResponse
    {
        public int statusCode { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public Data_ReRespStatus data { get; set; }
    }
    public class Root_DRLResponse
    {
        public string appointment_id { get; set; }
        public string doctor_id { get; set; }
        public string policy_id { get; set; }
        public string appointment_status { get; set; }
        public AppointmentDetails_DRLResponse appointment_details { get; set; }
        public string order_id { get; set; }
        public PaymentDetail_DRLResponse payment_detail { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }
    public class DR_PAYMENT_LINK
    {
        public string appointment_id { get; set; }
        public string payment_link { get; set; }
        public string payment_link_id { get; set; }
        public string expiry_date { get; set; }
        public string payment_amt { get; set; }
        public string active { get; set; }
    }

    public class DR_PHAR_PAYMENT_LINK
    {
        public string order_id { get; set; }
        public string payment_link { get; set; }
        public string payment_link_id { get; set; }
        public string expiry_date { get; set; }
        public string payment_amt { get; set; }
        public string active { get; set; }
    }


    public class DR_REFUND_STATUS
    {
        public string appointment_id { get; set; }
        public string refund_STATUS { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string refund_date { get; set; }
        public string refund_amt { get; set; }
        public string refund_id { get; set; }
        public string accept_refund_time { get; set; }
    }
    public class DR_PHARREFUND_STATUS
    {
        public string order_id { get; set; }
        public string refund_status { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string refund_date { get; set; }
        public string refund_amt { get; set; }
        public string refund_id { get; set; }
        public string accept_refund_time { get; set; }
    }
    public class DR_PAYMENT_STATUS
    {
        public string appointment_id { get; set; }
        public string payment_STATUS { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string payment_date { get; set; }
        public string payment_amt { get; set; }
        public string payment_mode { get; set; }
    }

    public class DR_PHARPAYMENT_STATUS
    {
        public string order_id { get; set; }
        public string payment_status { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string payment_date { get; set; }
        public string payment_amt { get; set; }
        public string payment_mode { get; set; }
    }



    public class DR_Response
    {
        public int Status { get; set; }
        public string ErrMsg { get; set; }
    }

    public class DRL_PharOrderStatus_Resp
    {
        public string error_code { get; set; }
        public string error_desc { get; set; }
    }


    public class DRL_PharOrderStatus_Resq
    {
        public string order_id { get; set; }
        public string order_status { get; set; }
    }

    public class DR_Diagnostic_Slot_Req
    {
        public string authorization_code { get; set; }
        public string business_id { get; set; }
        public string engagement_level { get; set; }
        public string from_date { get; set; }
        public string order_latitude { get; set; }
        public string order_longitude { get; set; }
        public string patient_age { get; set; }
        public string patient_gender { get; set; }
        public string pin_code { get; set; }
        public string service_did { get; set; }
        public string to_date { get; set; }
    }


    public class Address_Req_Drl
    {
        public string address { get; set; }
        public string addressType { get; set; }
        public string area { get; set; }
        public string landmark { get; set; }
        public string zipcode { get; set; }
        public string mandal { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int isDefaultAddress { get; set; }
        public int enabled { get; set; }
        public int isActive { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string createdBy { get; set; }
    }

    public class Root_CreateUser_Req_Drl
    {
        public List<Address_Req_Drl> address { get; set; }
        public string authorizationCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string salutation { get; set; }
        public string userName { get; set; }
        public string gender { get; set; }
        public string profilePicPath { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public int enabled { get; set; }
        public int isActive { get; set; }
        public string sourceType { get; set; }
        public string password { get; set; }
        public string createdBy { get; set; }
        public string memberId { get; set; }
        public string memberEmail { get; set; }
        public string designation { get; set; }
        public string insuranceId { get; set; }
        public string insuranceCompany { get; set; }
        public string uhid { get; set; }
    }

    public class DataObject_User_Res
    {
        public string authMrn { get; set; }
        public string accessToken { get; set; }
        public string source { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public int customerMRNID { get; set; }
        public string mrn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string userName { get; set; }
        public string salutation { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string alternateEmail { get; set; }
        public string alternateMobile { get; set; }
        public string dob { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string profilePicPath { get; set; }
        public string isActive { get; set; }
        public string sourceType { get; set; }
        public string sourceId { get; set; }
        public string consent { get; set; }
        public string isDependent { get; set; }
        public string businessSource { get; set; }
        public string parentMrn { get; set; }
        public string relation { get; set; }
        public string tenantCode { get; set; }
        public string organizationCode { get; set; }
        public string memberId { get; set; }
        public string memberEmail { get; set; }
        public string designation { get; set; }
        public string walletBalance { get; set; }
        public string createdBy { get; set; }
        public string modifiedBy { get; set; }
        public string otpExternal { get; set; }
    }

    public class Root_User_Res_drl
    {
        public DataObject_User_Res dataObject { get; set; }
        public string reason { get; set; }
        public int statusCode { get; set; }
        public string status { get; set; }
    }

    public class DRL_Address_Req
    {
        public string address { get; set; }
        public string addressType { get; set; }
        public string area { get; set; }
        public string authorization_code { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string createdBy { get; set; }
        public string customerMRNID { get; set; }
        public string district { get; set; }
        public int enabled { get; set; }
        public int isDefaultAddress { get; set; }
        public string landmark { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string mandal { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
    }

    public class DRL_Address_Res_Sub
    {
        public string authMrn { get; set; }
        public string accessToken { get; set; }
        public object source { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public string customerAddrID { get; set; }
        public string customerMRNID { get; set; }
        public string addressType { get; set; }
        public string isDefaultAddress { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string mandal { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string area { get; set; }
        public string landmark { get; set; }
        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string enabled { get; set; }
        public string createdBy { get; set; }
        public string modifiedBy { get; set; }
    }

    public class DRL_Address_Res_main
    {
        public string status { get; set; }
        public string statusCode { get; set; }
        public DRL_Address_Res_Sub dataObject { get; set; }
        public string reason { get; set; }
    }

    public class DiagOrderRequest
    {
        public CreateDiagnosticOrderRequest request { get; set; }
    }
    public class CreateDiagnosticOrderRequest
    {
        public string Past_slot_transaction_id { get; set; }
        public string address_id { get; set; }
        public string applicationNumber { get; set; }
        public string associate_branch_id { get; set; }
        public string associate_id { get; set; }
        public string authorization_code { get; set; }
        public string business_id { get; set; }
        public string caseRegisteredDate { get; set; }
        public string createdBy { get; set; }
        public string dateOfSharingData { get; set; }
        public decimal eligibility_amount { get; set; }
        public string engagement_level { get; set; }
        public string insurance_company { get; set; }
        public string insurance_id { get; set; }
        public string modifiedBy { get; set; }
        public string mrn { get; set; }
        public int number_of_tests { get; set; }
        public decimal order_amount { get; set; }
        public string past_scheduled_date { get; set; }
        public string patient_timeslot { get; set; }
        public decimal payable_by_insurance { get; set; }
        public decimal payable_by_user { get; set; }
        public int payable_by_user_GST { get; set; }
        public string scheduleDate { get; set; }
        public string tenant_order_id { get; set; }
        public string tenant_test_codes { get; set; }
        public string transactionID { get; set; }
        public string uhid { get; set; }
        public string user_address { get; set; }
        public string user_email_id { get; set; }
        public string user_name { get; set; }
        public bool is_flebo_charge { get; set; }
    }

    public class DiagnosticOrderReq
    {
        public CreateDiagnosticOrderRequest request { get; set; }
    }

    public class DRL_DiagOrder_response
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string response { get; set; }
        public string order_id { get; set; }
        public string tests { get; set; }
        public string value { get; set; }
        public payment_detail payment_details { get; set; }
    }
    public class DRL_PharmacyOrder_Response
    {
        public string drl_order_id { get; set; }
        public string message { get; set; }
    }



    public class DRL_ConfirmationResponse
    {
        public string message { get; set; }
    }

    public class payment_detail
    {
        public string linkId { get; set; }
        public string url { get; set; }
        public string expiryDate { get; set; }
    }

    public class IntegrationDiagOrderData_Request
    {
        public string rn_patientid { get; set; }
        public string rn_addressid { get; set; }
        public string entitycode { get; set; }
    }

    public class IntegrationDiagOrderData_Response
    {
        public string rn_patientid { get; set; }
        public string rn_addressid { get; set; }
        public string INT_patientid { get; set; }
        public string INT_addressid { get; set; }
        public string associate_branch_id { get; set; }
        public string associate_id { get; set; }
        public string patientemailid { get; set; }
    }

    public class DataToUpdateForDiagOrder
    {
        public string RN_AppointmentId { get; set; }
        public string INT_AppointmentId { get; set; }
        public string RN_DiagCode { get; set; }
        public string INT_DiagCode { get; set; }
        public string VisitType { get; set; }
        public string IntegrationId { get; set; }
        public string IntegrationCode { get; set; }
        public string payment_amt { get; set; }
        public string payment_link_id { get; set; }

        public string payment_link { get; set; }
        public string payment_link_expiry { get; set; }
        public string authorizationCode { get; set; }
    }

    public class diagnostic
    {
        public string diag_code { get; set; }
        public string report_url { get; set; }

    }
    public class DRL_AttachDiagnosticReport_request
    {
        public string appointment_id { get; set; }
        public List<diagnostic> diagnostics { get; set; }
    }

    public class DRL_Common_response
    {
        public string status { get; set; }
        public string msg { get; set; }
    }

    public class DRL_AttachDiagInvoice_request
    {
        public string appointment_id { get; set; }
        public string invoice_file_name { get; set; }
    }

    public class DRL_PharInvoice_request
    {
        public string order_id { get; set; }
        public string invoice_file_url { get; set; }
    }


    public class DRL_PharOfflineOrder_MedicineInfo
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public int orderedQty { get; set; }
        public int packSize { get; set; }
        public int mrp { get; set; }
        public double price { get; set; }
    }

    public class DRL_PharOfflineOrder_Response
    {
        public string drlOrderId { get; set; }
        public string ICICIorderId { get; set; }
        public string OrderId { get; set; }
        public string estimatedTimeOfArrival { get; set; }
        public double discountTotal { get; set; }
        public double orderTotal { get; set; }
        public int deliveryCharges { get; set; }
        public IList<DRL_PharOfflineOrder_MedicineInfo> medicineInfo { get; set; }
    }

    public class DRL_PharOfflineOrderResp
    {
        public string statusCode { get; set; }
        public object message { get; set; }
        public IList<DRL_PharOfflineOrder_Response> response { get; set; }
    }


    public class DRL_PharOfflineOrder_ProductInfo
    {
        public string productId { get; set; }
        public int packSize { get; set; }
        public int availableQty { get; set; }
        public int requestedQty { get; set; }
        public int noOfPacks { get; set; }
        public int mrp { get; set; }
        public double salePrice { get; set; }
        public int itemSeqId { get; set; }
    }

    public class DRL_PharOfflineOrder_MedicineInfo_Req
    {
        public string storeId { get; set; }
        public string eta { get; set; }
        public int orderTotal { get; set; }
        public int deliveryCharges { get; set; }
        public IList<DRL_PharOfflineOrder_ProductInfo> productInfos { get; set; }
    }




    public class DRL_PharOfflineOrder_Req
    {
        public string Uhid { get; set; }
        public string authorization_code { get; set; }
        public string created_by { get; set; }
        public string customerName { get; set; }
        public string ICICIOrderId { get; set; }
        public string healthRecordId { get; set; }
        public string insurance_company { get; set; }
        public string latLong { get; set; }
        public IList<DRL_PharOfflineOrder_MedicineInfo_Req> medicineInfo { get; set; }
        public string mobileNumber { get; set; }
        public string order_amount { get; set; }
        public string policy_number { get; set; }
        public IList<string> prescription_url { get; set; }
        public DRL_ShippingAddress shippingAddress { get; set; }
    }

    public class DRL_PharStorOrder_Req
    {
        public string Uhid { get; set; }
        public string authorization_code { get; set; }
        public string created_by { get; set; }
        public string customerName { get; set; }
        public string insurance_id { get; set; }
        public string iciciOrderId { get; set; }
        public string insurance_company { get; set; }
        public IList<DRL_PharStoreOrder_MedicineInfo_Req> medicineInfo { get; set; }
        public string mobileNumber { get; set; }
        public string policy_number { get; set; }
        public IList<string> prescription_url { get; set; }
        public string storeId { get; set; }
        public string address { get; set; }
        public string state_code { get; set; }
    }


    public class DRL_PharStoreOrder_MedicineInfo_Req
    {
        public string medicine_id { get; set; }
        public string medicine_name { get; set; }
        public int qty { get; set; }
    }


    public class DRL_PharStoreOrderResp
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public DRL_PharStoreOrder_Response response { get; set; }
    }


    public class DRL_PharStoreOrder_Response
    {
        public string drlOrderId { get; set; }     
        public IList<DRL_PhaStoreOrder_MedicineInfo> medicineInfo { get; set; }
    }


    public class DRL_PhaStoreOrder_MedicineInfo
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string orderedQty { get; set; }
        public string packSize { get; set; }       
    }
    public class VideoConsultation_Req
    { 
         public string appointmentId { get; set; }
         public string consultationUrl { get; set; }
    }
    public class VideoConsultation_Resp
    { 
         public int Status { get; set; }
        public string Message { get; set; }
    }

    public class GetVideoConLink
    {
        public string appointmentId { get; set; }
        public bool hasConsultationUrl { get; set; }
        public string econsultationUrl { get; set; }
    }
}
