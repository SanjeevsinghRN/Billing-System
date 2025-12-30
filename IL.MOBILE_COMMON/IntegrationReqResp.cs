using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class FalckTokenAuthRequest
    {
        public string Mobile { get; set; }
    }

    public class FalckTokenAuthResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }

    public class FalckSendDetails
    {
        public string PatientName { get; set; }
        public string CustomerName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PolicyNo { get; set; }
        public string UHID { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Coverage { get; set; }
        public string Eligibility { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpeciality { get; set; }
        public string HospitalCode { get; set; }
        public string DoctorCode { get; set; }
        public string DocRegistrationNo { get; set; }
        public string SpecialtyCode { get; set; }
        public string DOB { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TeleConsultCount { get; set; }
    }

    public class DRL_MedicineInfo
    {
        public string productId { get; set; }
        public string requestedQty { get; set; }
    }

    public class DRL_ShippingAddress
    {
        public string address { get; set; }
        public string doorNo { get; set; }
        public string firstName { get; set; }
        public string mobileNumber { get; set; }
        public string streetName { get; set; }
    }

    public class DRL_Order_Request
    {
        public string authorization_code { get; set; }
        public string created_by { get; set; }
        public string customerName { get; set; }
        public string healthRecordId { get; set; }
        public string iciciOrderId { get; set; }
        public string insurance_company { get; set; }
        public string latLong { get; set; }
        public List<DRL_MedicineInfo> medicineInfo { get; set; }
        public string mobileNumber { get; set; }
        public string pickStoreId { get; set; }
        public string policy_number { get; set; }
        public List<string> prescription_url { get; set; }
        public DRL_ShippingAddress shippingAddress { get; set; }
        public string uhid { get; set; }
    }

    public class MedPay_Address_details
    {
        public string address { get; set; }
        public string landmark { get; set; }
        public string pin_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string coordinates { get; set; }

    }


    public class MedPay_Customer_details
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string alternative_mobile { get; set; }
        public string email { get; set; }
        public MedPay_Address_details address_details { get; set; }

    }

    public class MedPay_Items
    {
        public string item_code { get; set; }
        public string item { get; set; }
        public int quantity_in_pack { get; set; }
        public int quantity_in_loose { get; set; }
    }

    public class MedPay_Order_details
    {
        public List<string> prescription_links { get; set; }
        public List<MedPay_Items> items { get; set; }

    }

    public class MedPay_PharOrderRequest
    {
        public string icici_orderid { get; set; }
        public string partner_name { get; set; }
        public string payment_collection { get; set; }
        public string delivery_partner { get; set; }
        public MedPay_Customer_details customer_details { get; set; }
        public MedPay_Order_details order_details { get; set; }

    }

    public class Medpay_ConsultationAppointmentRequest
    {
        public string booking_id { get; set; }
        public string partner_order_id { get; set; }
        public string specialty { get; set; }
        public string partner_name { get; set; }
        public string payment_collection { get; set; }
        public string time_slot { get; set; }
        public string consultation_fees { get; set; }
        public string payer_payable { get; set; }
        public string patient_payable { get; set; }
        public customer_details customer_details { get; set; }
    }

    public class MedPay_PharOrderResposne
    {
        public string status { get; set; }
        public string message { get; set; }
        public MedPay_Response response { get; set; }

    }
    public class MedPay_ConsultationOrderResposne1
    {
        public string status { get; set; }
        public string message { get; set; }
        public MedPay_Consultation_Response response { get; set; }
        public string errors { get; set; }

    }
    public class MedPay_Consultation_Response
    {
        public string partner_order_id { get; set; }
        public string payment_collection { get; set; }
        public string partner_name { get; set; }
        public string specialty { get; set; }
        public string order_status { get; set; }
        public booking_details booking_details { get; set; }
        public customer_details customer_details { get; set; }
        public string created_by { get; set; }
        public string created_at { get; set; }

    }
    public class booking_details
    {
        public string time_slot { get; set; }
        public string specialties { get; set; }
        public string clinic_name { get; set; }
        public string clinic_address { get; set; }
        public string coordinates { get; set; }

    }
    public class customer_details
    {
        public string uhid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public int? age { get; set; }
        public string alternative_mobile { get; set; }
        public string email { get; set; }
        public address_details_response address_details { get; set; }
        public policy_details policy_details { get; set; }
    }
    public class address_details_response
    {
        public string address { get; set; }
        public string landmark { get; set; }
        public string pin_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
       // public string coordinates { get; set; }

    }
    public class policy_details
    {
        public string name { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public string uhid { get; set; }
        public string policyno { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public dependants dependants { get; set; }
        public string status { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string corporateName { get; set; }
        public string policyName { get; set; }

    }
    public class dependants
    {
        public string name { get; set; }
        public string relation { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string mobile_number { get; set; }
        public string uhid { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }

    }
    public class MedPay_Response
    {
        public string partner_order_id { get; set; }
        public string payment_collection { get; set; }
        public string delivery_partner { get; set; }
        public string partner_name { get; set; }
        public string order_status { get; set; }
        public MedPay_Customer_details customer_details { get; set; }
        public MedPay_Order_details order_details { get; set; }
        public string created_by { get; set; }
        public string created_at { get; set; }

    }

    public class MedPay_PhrOnlineOrderCancelRequest
    {
        public string icici_order_id { get; set; }
        public string partner_order_id { get; set; }
        public string partner_name { get; set; }
        public string cancelled_reason { get; set; }

    }


    public class MedPayCancelResposne
    {
        public string partner_order_id { get; set; }
        public string partner_name { get; set; }
        public string order_status { get; set; }
        public string cancelled_reason { get; set; }
        public string cancelled_by { get; set; }
        public string cancelled_at { get; set; }

    }

    
    public class MedPay_PharOnlineOrderCancelResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public MedPayCancelResposne response { get; set; }

    }

    public class MedPay_ConfirmOrderRequest
    {
        public string partner_order_id { get; set; }
        public string partner_name { get; set; }
        public string delivery_partner { get; set; }
        public string order_amount { get; set; }
        public string payer_payable { get; set; }
        public string patient_payable { get; set; }
        public IList<MedPay_Confirmed_items> confirmed_items { get; set; }

    }


    public class MedPay_Confirmed_items
    {
        public string item_code { get; set; }
        public string item { get; set; }
        public string manufacturer { get; set; }
        public string details { get; set; }
        public string MRP { get; set; }
        public int quantity { get; set; }

    }



    public class MedPay_OrderResponse
    {
        public string partner_order_id { get; set; }
        public string partner_name { get; set; }
        public MedPay_Order_details order_details { get; set; }
        public string order_status { get; set; }
        public string created_at { get; set; }
        public string modified_at { get; set; }

    }

    public class MedPay_ConfirmOrderResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public MedPay_OrderResponse response { get; set; }

    }
    public class BookingDetails
    {
        public string time_slot { get; set; }
        public string specialties { get; set; }
        public string clinic_name { get; set; }
        public string clinic_address { get; set; }
        public string coordinates { get; set; }
    }

    public class AddressDetails
    {
        public string address { get; set; }
        public string landmark { get; set; }
        public string pin_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class Dependant
    {
        public string name { get; set; }
        public string relation { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string mobile_number { get; set; }
        public string uhid { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
    }

    public class PolicyDetails1
    {
        public string name { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public string uhid { get; set; }
        public string policyno { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public List<Dependant> dependants { get; set; }
        public string status { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string corporateName { get; set; }
        public string policyName { get; set; }
    }

    public class CustomerDetails
    {
        public string uhid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string alternative_mobile { get; set; }
        public string email { get; set; }
        public AddressDetails address_details { get; set; }
        public PolicyDetails1 policy_details { get; set; }
    }

    public class Response1
    {
        public string partner_order_id { get; set; }
        //public string payment_collection { get; set; }
        //public string partner_name { get; set; }
        //public string specialty { get; set; }
        //public string order_status { get; set; }
        //public BookingDetails booking_details { get; set; }
        //public CustomerDetails customer_details { get; set; }
        //public string created_by { get; set; }
        //public string created_at { get; set; }
    }

    public class MedPay_ConsultationOrderResposne
    {
        public string status { get; set; }
        public string message { get; set; }
        public Response1 response { get; set; }
        public string errors { get; set; }
    }
    public class MEDPAY_ConsultationCancelOrderRequest
    {
        public string partner_name { get; set; }
        public string partner_order_id { get; set; }
        public string cancelled_reason { get; set; }

    }
    public class MedPay_ConsultationCancelOrderResposne
    {
        public string status { get; set; }
        public string message { get; set; }
        public string errors { get; set; }

        public Medpay_AppointmentDetails_RSP response { get; set; }
    }
    public class Medpay_AppointmentDetails_RSP
    {
        public string partner_order_id { get; set; }
        public string partner_name { get; set; }
        public string cancelled_reason { get; set; }

    }



}
