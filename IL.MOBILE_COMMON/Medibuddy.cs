using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class Medibuddy
    {
    }
    public class user_request
    {
        public string memberId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string emailId { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string grade { get; set; }
        public int policyId { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string relation { get; set; }
        public Metadata_user_request metadata { get; set; }
    }
    public class Metadata_user_request
    {
        public string policyId { get; set; }
    }

    public class user_Data
    {
        public int userId { get; set; }
        public int beneficiaryId { get; set; }
    }

    public class user_response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public user_Data data { get; set; }
        public string error { get; set; }
    }

    public class Create_beneficiary_rqst
    {
        public int userId { get; set; }
        public string beneficiaryFirstName { get; set; }
        public string beneficiaryLastName { get; set; }
        public string beneficiaryMobileNumber { get; set; }
        public string beneficiaryEmailId { get; set; }
        public string beneficiaryDateOfBirth { get; set; }
        public string beneficiaryGender { get; set; }
        public string beneficiaryAddress { get; set; }
        public string beneficiaryPincode { get; set; }
        public string relation { get; set; }
    }

    #region get_servicable_pincodes
    public class MEDIBUDDY_PINCODE_RESPONSE
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public DATA_PINCODE data { get; set; }
        public string error { get; set; }
    }
    public class DATA_PINCODE
    {
        public List<int> pincodes { get; set; }

    }

    public class Medibuddy_package_pincode_request
    {
        public List<int> packageIds { get; set; }
    }

    public class MEDIBUDDY_PINCODE_RESPONSE_SDatum
    {
        public int packageId { get; set; }
        public string packageType { get; set; }
        public List<int> servingPincodes { get; set; }
    }

    public class MEDIBUDDY_PINCODE_RESPONSE_S
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public List<MEDIBUDDY_PINCODE_RESPONSE_SDatum> data { get; set; }
    }


    #endregion

    #region get_package_details
    public class MEDIBUDDY_PACKAGE_REQUEST
    {
        public int packageId { get; set; }
        public string pincode { get; set; }
    }
    public class MEDIBUDDY_PACKAGE_RESPONSE
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public DATA_PACKAGE data { get; set; }
        public string error { get; set; }
    }
    public class DATA_PACKAGE
    {
        public int packageId { get; set; }
        public string packageName { get; set; }
        public List<PackageTest> packageTests { get; set; }
        public List<PackageProfile> packageProfiles { get; set; }
        public List<string> visitType { get; set; }
        public string preRequisites { get; set; }
        public bool homeVisitAvailable { get; set; }
        public bool centerVisitAvailable { get; set; }
        public List<Provider1> providers { get; set; }
        public bool isSuccess { get; set; }
        public int contractId { get; set; }
    }
    public class PackageTest
    {
        public string packageTestGroupName { get; set; }
        public string packageTestName { get; set; }
        public int packageTestGroupId { get; set; }
        public string packageTestCode { get; set; }
        public string packageTestDescription { get; set; }
        public int packageTestId { get; set; }
    }
    public class PackageProfile
    {
        public int packageProfileId { get; set; }
        public string packageProfileGroupName { get; set; }
        public int packageProfileGroupId { get; set; }
        public List<PackageTest> packageTests { get; set; }
        public string packageProfileName { get; set; }
        public string packageProfileCode { get; set; }
    }
    public class Provider1
    {
        public int providerId { get; set; }
        public string providerName { get; set; }
        public string providerAddress { get; set; }
        public ProviderLatLong providerLatLong { get; set; }
    }
    public class ProviderLatLong
    {
        public string providerLocationLatitude { get; set; }
        public string providerLocationLongitude { get; set; }
    }
    #endregion

    #region Get_specialities
    public class MEDIBUDDY_SPECIALISTS_RESPONSE
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public DATA_SPECIALITIES data { get; set; }
        public string error { get; set; }
    }
    public class DATA_SPECIALITIES
    {
        public List<Specialities> specialities { get; set; }
    }
    public class Specialities
    {
        public string id { get; set; }
        public string title { get; set; }
        public string speciality { get; set; }
    }
    #endregion

    #region Get_doctors
    public class MEDIBUDDY_GETDOCTORS_REQUEST
    {
        public string city { get; set; }
        public string locality { get; set; }
        public string specialityId { get; set; }
        public int startPage { get; set; }
        public int pageLimit { get; set; }
    }
    public class MEDIBUDDY_GETDOCTORS_RESPONSE
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public DATA_DOCTORS data { get; set; }
        public string error { get; set; }
    }
    public class DATA_DOCTORS
    {
        public List<Doctor> doctors { get; set; }
    }
    public class Doctor
    {
        public string doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorProfileImage { get; set; }
        public string doctorExperience { get; set; }
        public string doctorSpecialization { get; set; }
        public int doctorConsultationFees { get; set; }
        public string doctorAddress { get; set; }
        public string hospitalCity { get; set; }
        public string doctorQualification { get; set; }
        public string doctorClinicName { get; set; }
        public List<Slot> slots { get; set; }
    }
    public class Slot
    {
        public string slotId { get; set; }
        public DateTime slotStartTime { get; set; }
        public DateTime slotEndTime { get; set; }
        public string timeZone { get; set; }
    }
    #endregion

    #region Book Order Request
    public class Order
    {
        public string trackingId { get; set; }
        public int amount { get; set; }
        public int prePaidTotalAmount { get; set; }
        public int customerPaidAmount { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }

    public class OrderItem
    {
        public int packageId { get; set; }
        public int providerId { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public string memberId { get; set; }
        public int quantity { get; set; }
        public string relation { get; set; }
        public string visitType { get; set; }
        public int slotId { get; set; }
        public int prePaidAmount { get; set; }
        public string alternateEmail { get; set; }
    }

    public class Book_Order_rqst
    {
        public User_Book_Order user { get; set; }
        public Order order { get; set; }
    }

    public class User_Book_Order
    {
        public string memberId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string emailId { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string grade { get; set; }
        public int policyId { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string relation { get; set; }
    }

    #endregion

    #region Book Order Response

    public class Book_Order_response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Data_res data { get; set; }
        public string error { get; set; }
    }
    public class Data_res
    {
        public string bookingId { get; set; }
        public string trackingId { get; set; }
        public string customerPaymentLink { get; set; }
    }


    #endregion

    #region Reschedule Request
    public class RescheduleSlotId
    {
        public string bookingItemId { get; set; }
        public int id { get; set; }
    }

    public class Reschedule_rqst
    {
        public string bookingId { get; set; }
        public string rescheduleReason { get; set; }
        public List<RescheduleSlotId> rescheduleSlotId { get; set; }
    }
    #endregion

    #region Reschedule Response
    public class Reschedule_Data
    {
        public List<RescheduleOrder> rescheduleOrder { get; set; }
    }

    public class RescheduleOrder
    {
        public int bookingItemId { get; set; }
        public string bookingStatus { get; set; }
    }


    public class Reschedule_response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Reschedule_Data data { get; set; }
        public string error { get; set; }
    }

    #endregion

    #region OPD-Cosults
    public class opd_consults_order_MetaData
    {
        public string partnerKey { get; set; }
    }

    public class opd_consults_order_rqst
    {
        public int userId { get; set; }
        public int beneficiaryId { get; set; }
        public string slotId { get; set; }
        public string doctorId { get; set; }
        public string specialityId { get; set; }
        public int prePaidTotalAmount { get; set; }
        public int customerPaidAmount { get; set; }
        public string trackingId { get; set; }
        public string policyId { get; set; }
        public opd_consults_order_MetaData metaData { get; set; }
        public bool dnd { get; set; }
    }



    public class opd_consults_order_reschedule_rqst
    {
        public string bookingId { get; set; }
        public string trackingId { get; set; }
        public string rescheduleReason { get; set; }
        public string slotId { get; set; }
    }


    public class reschedule_opd_resp_Data
    {
        public List<RescheduleOrder_consul> rescheduleOrder { get; set; }
    }
    public class RescheduleOrder_consul
    {
        public string bookingItemId { get; set; }
        public string bookingStatus { get; set; }
        public DateTime rescheduleDate { get; set; }
    }
    public class reschedule_opd_resp
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public reschedule_opd_resp_Data data { get; set; }
        public string error { get; set; }
    }

    public class BeneficiaryDetail_Medi
    {
        public int beneficiaryId { get; set; }
        public string beneficiaryName { get; set; }
        public string gender { get; set; }
        public string mobileNumber { get; set; }
        public string emailId { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string relationWithPrimaryUser { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
    }

    public class get_user_Data
    {
        public UserDetails userDetails { get; set; }
        public List<BeneficiaryDetail_Medi> beneficiaryDetails { get; set; }
    }

    public class get_user_res
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public get_user_Data data { get; set; }
        public string error { get; set; }
    }

    public class UserDetails
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailId { get; set; }
        public string mobileNumber { get; set; }
        public string memberId { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }
    }


    public class Get_Order_Details_Data
    {
        public int bookingId { get; set; }
        public List<Request> requests { get; set; }
        public Get_Order_Details_MetaData metaData { get; set; }
    }

    public class Get_Order_Details_MetaData
    {
        public string partnerKey { get; set; }
        public string dummy { get; set; }
    }

    public class Request
    {
        public int requestId { get; set; }
        public int requestStatus { get; set; }
        public DateTime appointmentDate { get; set; }
        public string productName { get; set; }
        public int beneficiaryId { get; set; }
        public string patientName { get; set; }
        public List<object> documents { get; set; }
        public int productType { get; set; }
        public int corporateId { get; set; }
        public int erId { get; set; }
    }

    public class Get_Order_Details_resp
    {
        public Get_Order_Details_Data data { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }

        public string error { get; set; }
    }


    public class cancel_order_Data
    {
        public List<object> cancelOrder { get; set; }
    }

    public class cancel_order
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public cancel_order_Data data { get; set; }
        public string error { get; set; }
    }

    public class cancel_order_rqst
    {
        public string bookingId { get; set; }
        public string cancellationReason { get; set; }
    }


    public class get_users_orders_rqst_Datum
    {
        public int bookingId { get; set; }
        public List<get_users_orders_rqst_Request> requests { get; set; }
    }

    public class get_users_orders_rqst_Request
    {
        public int requestId { get; set; }
        public int requestStatus { get; set; }
        public DateTime appointmentDate { get; set; }
        public string productName { get; set; }
        public string beneficiaryId { get; set; }
        public string patientName { get; set; }
        public int productType { get; set; }
        public string corporateId { get; set; }
        public string erId { get; set; }
    }

    public class get_users_orders_rqst
    {
        public List<get_users_orders_rqst_Datum> data { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    public class online_consults_order_MetaData
    {
        public string partnerKey { get; set; }
    }

    public class online_consults_order_rqst
    {
        public int userId { get; set; }
        public int beneficiaryId { get; set; }
        public string specialityId { get; set; }
        public string problemDescription { get; set; }
        public online_consults_order_MetaData metaData { get; set; }
        public string trackingId { get; set; }
        public string policyId { get; set; }
    }

    public class online_consults_order_Data
    {
        public string bookingId { get; set; }
        public string trackingId { get; set; }
    }

    public class online_consults_order_rspe
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public online_consults_order_Data data { get; set; }
        public string error { get; set; }
    }


    #endregion

    #region labs_get_slots
    public class labs_get_slots_request
    {
        public int packageId { get; set; }
        public int pincode { get; set; }
        public AddressInfo addressInfo { get; set; }
        public List<int> providerIds { get; set; }
    }
    public class AddressInfo
    {
        public string address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class labs_get_slots_response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Data_labs_get_slots data { get; set; }
        public string error { get; set; }
    }

    public class Data_labs_get_slots
    {
        public List<ProviderSlot> providerSlot { get; set; }
    }

    public class ProviderSlot
    {
        public int providerId { get; set; }
        public List<DaySlot> daySlots { get; set; }
    }

    public class DaySlot
    {
        public int dayOfWeek { get; set; }
        public string date { get; set; }
        public string dateString { get; set; }
        public int availableSlots { get; set; }
        public int totalSlots { get; set; }
        public int providerId { get; set; }
        public WorkingDaySlots workingDaySlots { get; set; }
    }

    public class WorkingDaySlots
    {
        public string dayOfWeek { get; set; }
        public List<Labs_Slot> slots { get; set; }
        public int day { get; set; }
    }

    public class Labs_Slot
    {
        public int slotStartTime { get; set; }
        public int slotEndTime { get; set; }
        public string slotStartDateTime { get; set; }
        public string slotEndDateTime { get; set; }
        public int slotCount { get; set; }
        public bool slotAvailable { get; set; }
        public List<int> servingProviders { get; set; }
        public string realtimePhlebo { get; set; }
        public int slotId { get; set; }
        public string slotlabel { get; set; }
    }

    #endregion

    #region labs_book_order
    public class Labs_book_order_request
    {
        public User_labs user { get; set; }
        public Order_labs order { get; set; }
    }
    public class User_labs
    {
        public int userId { get; set; }
        public int beneficiaryId { get; set; }
        public int policyId { get; set; }
    }
    public class Order_labs
    {
        public string trackingId { get; set; }
        public int amount { get; set; }
        public int prePaidTotalAmount { get; set; }
        public int customerPaidAmount { get; set; }
        public List<OrderItem_labs> orderItems { get; set; }
    }

    public class OrderItem_labs
    {
        public int packageId { get; set; }
        public int providerId { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public string memberId { get; set; }
        public int quantity { get; set; }
        public string relation { get; set; }
        public string visitType { get; set; }
        public int slotId { get; set; }
        public int prePaidAmount { get; set; }
        public string alternateEmail { get; set; }
    }
    public class Labs_book_order_response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Data_book_order data { get; set; }
        public string error { get; set; }
    }
    public class Data_book_order
    {
        public string bookingId { get; set; }
        public string trackingId { get; set; }
        public string customerPaymentLink { get; set; }
    }
    #endregion

    #region labs order status
    public class Root
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }
    #endregion


    public class Medibuddy_Response
    {
        public int Status { get; set; }
        public string ErrMsg { get; set; }
    }
    public class MEDIBUDDY_PAYMENT_LINK
    {
        public string appointment_id { get; set; }
        public string payment_link { get; set; }
        public string payment_link_id { get; set; }
        public string expiry_date { get; set; }
        public string payment_amt { get; set; }
        public string active { get; set; }
    }
    public class MEDIBUDDY_PAYMENT_STATUS
    {
        public string appointment_id { get; set; }
        public string payment_STATUS { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string payment_date { get; set; }
        public string payment_amt { get; set; }
        public string payment_mode { get; set; }
    }
    public class MEDIBUDDY_REFUND_STATUS
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
    public class MEDIBUDDY_ValidateOTPMain
    {
        public MEDIBUDDY_ValidateOTP data { get; set; }
    }
    public class MEDIBUDDY_ValidateOTP
    {
        public string appointment_id { get; set; }
        public string otp { get; set; }
    }
    public class MEDIBUDDY_ValidateResp
    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }
}
