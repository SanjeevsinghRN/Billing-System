using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RN.MOBILE_COMMON
{
    public class IntegrationAuthTokens
    {
        public string PatientId { get; set; }
        public string Authorizationcode { get; set; }
        public string Accesstoken { get; set; }
        public string RefreshToken { get; set; }
        public bool IsReAuthorizationReq { get; set; }
        public string CLIENT_ID { get; set; }
        public string Redirect_Uri { get; set; }
        public string Practo_Auth_Uri { get; set; }
        public string Practo_Book_Uri { get; set; }
    }

    public class PractoAuthResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }


    public class IntegrationRequestLogs
    {
        public string Integration_Request { get; set; }
        public string Source { get; set; }
        public string TRIGGER_USER_ID { get; set; }
        public string PATIENT_ID { get; set; }
        public string GUID { get; set; }
        public int INTEGRATION_ID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int City_ID { get; set; }

    }

    public class OnemgTokenClassRequest
    {
        public string doctor_id { get; set; }
        public string clinic_id { get; set; }
        public string patient_uhid { get; set; }
        public string patient_name { get; set; }
        public string patient_email { get; set; }
        public string patient_mobile_number { get; set; }
        public string patient_gender { get; set; }
        public string patient_age { get; set; }

        public string IPAddress { get; set; }

        public string DeviceID { get; set; }

        public string TRIGGER_USER_ID { get; set; }

    }

    public class OnemgReschToken
    {
        public string appointment_id { get; set; }
    }

    public class OnemgBadRequest
    {
        public string error { get; set; }
        public string message { get; set; }
    }
    public class OnemgAppointmentCancelReq
    {
        public string status { get; set; } = "cancel";
        public string reason { get; set; }
    }


    public class OnemgTokenResponse
    {
        public string token { get; set; }
        public string error { get; set; }
        public string is_error { get; set; }
    }


    public class OnemgTokenClassRequestv1
    {
        public string doctor_id { get; set; }
        public string clinic_id { get; set; }
        public string patient_uhid { get; set; }
        public string patient_name { get; set; }
        public string patient_email { get; set; }
        public string patient_mobile_number { get; set; }
        public string patient_gender { get; set; }
        public string patient_age { get; set; }
    }
}

namespace RN.MOBILE_COMMON.RN_INTEGRATION
{
    public class ProviderNetworkResponse
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public List<HII_Result_Details> ProviderData { get; set; }
    }
    public class ICICITokenRequest
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string scope { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    public class ICICITokenResponse
    {
        public string access_token { get; set; }
        public Int64 expires_in { get; set; }
        public string client_secret { get; set; }
        public string token_type { get; set; }
    }

    public class EnrollmentDetailsResponse
    {
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Relation { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Age { get; set; }
        public string InsuredStatus { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGrade { get; set; }
        public string EmployeeLocation { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmailId { get; set; }
        public string InsuredMobile { get; set; }
        public string PolicyStartDate { get; set; }
        public string PolicyEndDate { get; set; }
        public string DateofPolicyJoining { get; set; }
        public string PolicyResignDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public string BaseSumInsured { get; set; }
        public string TopUpSumInsured { get; set; }
        public string EndorsementNumber { get; set; }
        public string EndorsementDate { get; set; }
        public string EndorsementType { get; set; }
        public string ProductName { get; set; }
        public string Remarks { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public string errorMsg { get; set; }
        public dynamic result { get; set; }
    }
    public class ResponseClaimsData
    {
        public string status { get; set; }
        public string errorMsg { get; set; }
        public List<HII_ClaimList_Result> result { get; set; }
    }
    public class EnrollmentDetailsRequest
    {
        public string PolicyNumber { get; set; }
        public string AuthId { get; set; }
        public string EmployeeNumber { get; set; }
        public string MemberID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class ECardRequest
    {
        public string PolicyNumber { get; set; }
        public string AuthId { get; set; }
        public string EmployeeNumber { get; set; }
        public string MemberID { get; set; }
        public string TPAId { get; set; }
        public string Device { get; set; }
    }

    public class ECard
    {
        public string PolicyNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string TPAId { get; set; }
        public string MemberID { get; set; }
        public string ECardUrl { get; set; }
    }

    public class HII_NetworkHospitals_Request
    {
        public string Count { get; set; }
        public string StartIndex { get; set; }
        public string EndIndex { get; set; }
        public string AuthId { get; set; }

        public string PolicyNo { get; set; }
    }


    public class HII_Result_Cnt
    {
        public string Count { get; set; }
    }
    public class HII_Result_Details
    {
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string Pincode { get; set; }
        public string Landmark1 { get; set; }
        public string Landmark2 { get; set; }
        public string STDCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string LevelOfCare { get; set; }
        public object RohiniCode { get; set; }
        public string InsuranceCompany { get; set; }
    }
        
    public class ExtensionData
    {
    }

    public class MediBuddyClaimSData
    {
        public ExtensionData ExtensionData { get; set; }
        public string INSURANCE_COMPANY_NAME { get; set; }
        public string GROUP_CODE { get; set; }
        public string GROUP_NAME { get; set; }
        public string POLICY_NUMBER { get; set; }
        public string COMMENCEMENT_DATE { get; set; }
        public string VALID_UPTO { get; set; }
        public string TPA_HEALTH_ID { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_NO { get; set; }
        public string AGE { get; set; }
        public string RELATION { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string GENDER { get; set; }
        public string SUM_INSURED { get; set; }
        public string GRADE { get; set; }
        public string SUB_GROUP { get; set; }
        public string CITY { get; set; }
        public string INSURANCE_CLAIM_NO { get; set; }
        public string TPA_CLAIM_NO { get; set; }
        public string TPA_CLAIM_EXTENSION { get; set; }
        public string PARTIAL_PAYMENT_SEQUENCE { get; set; }
        public string UNIQUE_CLAIM { get; set; }
        public string CLAIM_REGISTERED_DATE { get; set; }
        public string PRE_AUTH_SENT { get; set; }
        public string PRE_AUTH_REQUEST_DATE { get; set; }
        public string PRE_AUTH_SENT_DATE { get; set; }
        public string PRE_AUTH_AMOUNT { get; set; }
        public string ESTIMATED_CLAIM_AMOUNT { get; set; }
        public string HOSPITAL_NO { get; set; }
        public string HOSPITAL_NAME { get; set; }
        public string NETWORK_STATUS { get; set; }
        public string HOSPITAL_CITY { get; set; }
        public string HOSPITAL_STATE { get; set; }
        public string LEVEL_OF_CARE { get; set; }
        public string AILMENT { get; set; }
        public string FINAL_DIAGNOSIS { get; set; }
        public string DISEASE_CATEGORY { get; set; }
        public string ICD_CODE { get; set; }
        public string DATE_OF_ADMISSION { get; set; }
        public string DATE_OF_DISCHARGE { get; set; }
        public string LENGTH_OF_STAY { get; set; }
        public string FILE_RECEIVED_DATE { get; set; }
        public string DEFICIENCIES_IR_REQUIREMENT { get; set; }
        public string FIRST_DEFICIENCY_LETTER_DATE { get; set; }
        public string SECOND_DEFICIENCY_LETTER_DATE { get; set; }
        public string DEFICIENCY_INTIMATED_DATE { get; set; }
        public string DEFICIENCIES_RETRIEVED_DATE { get; set; }
        public string FINAL_BILL_AMOUNT { get; set; }
        public string NON_PAYABLE_EXPENSES { get; set; }
        public string CO_PAYMENT_DEDUCTIONS { get; set; }
        public string BUFFER_UTILISED_AMOUNT { get; set; }
        public string DEDUCTION_REASONS { get; set; }
        public string ROOM_RENT_DAY_OPTED { get; set; }
        public string TOTAL_ROOM_NURSING_CHARGES { get; set; }
        public string SURGERY_CHARGES { get; set; }
        public string CONSULTANT_CHARGES { get; set; }
        public string INVESTIGATION_CHARGES { get; set; }
        public string MEDICINE_CHARGES { get; set; }
        public string MISCELLANEOUS_CHARGES { get; set; }
        public string DATE_OF_SETTLEMENT { get; set; }
        public string DATE_OF_PAYMENT_TO_PROVIDER { get; set; }
        public string AMOUNT_PAID_TO_PROVIDER { get; set; }
        public string BANK_CHEQUE_NO { get; set; }
        public string FLOAT_AC_NO { get; set; }
        public string DATE_OF_PAYMENT_TO_MEMBER { get; set; }
        public string AMOUNT_PAID_TO_MEMBER { get; set; }
        public string CHEQUE_NO_TO_MEMBER { get; set; }
        public string BALANCE_SI { get; set; }
        public string SERVICE_TAX_NO { get; set; }
        public string SERVICE_TAX_AMOUNT { get; set; }
        public string TDS_AMOUNT { get; set; }
        public string REPORTED_AMOUNT { get; set; }
        public string AMOUNT { get; set; }
        public string PAID_AMOUNT { get; set; }
        public string CLAIM_APPROVED_AMOUNT { get; set; }
        public string PAID_DATE { get; set; }
        public string REJECTED_CLOSE_DATE { get; set; }
        public string TYPE_OF_CLAIM { get; set; }
        public string STATUS { get; set; }
        public string OUTSTANDING_CLAIM_STATUS { get; set; }
        public string CASHLESS_DENIAL_REASONS { get; set; }
        public string REASON_FOR_CLOSURE { get; set; }
        public object CANCELLEDDATE { get; set; }
        public string ISCLAIMACTIVE { get; set; }
        public object TREATMENTTYPE { get; set; }
        public string BANK_NAME { get; set; }
        public string BANK_BRANCH { get; set; }
        public string BANK_ADDRESS { get; set; }
        public object CHEQUEDATE { get; set; }
        public object IFSCCODE { get; set; }
        public string AILMENT_DESC { get; set; }
        public object AILMENT_GROUP { get; set; }
        public int STATUS_ID { get; set; }
        public string LASTUPDATEDDATE { get; set; }
        public string CREATED_DATE { get; set; }
        public string HOSPITAL_ADDRESS { get; set; }
        public string HOSP_PINCODE { get; set; }
    }

    public class HII_ClaimList_Request
    {
        public string PolicyNumber { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AuthId { get; set; }
        public string EmployeeNumber { get; set; }
        public string MemberID { get; set; }
        public string Device { get; set; }
    }

    public class HII_ClaimList_Result
    {
        public string POLICY_NUMBER { get; set; }
        public string TPA_ID { get; set; }
        public string EMPLOYEE_NO { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string COMMENCEMENT_DATE { get; set; }
        public string PATIENT_NAME { get; set; }
        public string GENDER { get; set; }
        public string PATIENT_REALTION { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string AGE { get; set; }
        public string TPA_CLAIM_NO { get; set; }
        public string INSURANCE_CLAIM_NO { get; set; }
        public string DISCREPANCY_ID { get; set; }
        public string DEFICIENCIES_IR_REQUIREMENT { get; set; }
        public string DISCREPANCY_STATUS { get; set; }
        public string DEFICIENCY_INTIMATED_DATE { get; set; }
        public string FIRST_DEFICIENCY_LETTER_DATE { get; set; }
        public string SECOND_DEFICIENCY_LETTER_DATE { get; set; }
        public string EXPECTED_CLOSURE_DATE { get; set; }
        public string ACTUAL_CLOSURE_DATE { get; set; }
        public string REOPEN_DATE { get; set; }
        public string TPA_CLAIM_EXTENSION { get; set; }
        public string DEFICIENCIES_RETRIEVED_DATE { get; set; }
        public string DATE_OF_PAYMENT_TO_MEMBER { get; set; }
        public string AMOUNT_PAID_TO_MEMBER { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public string BANK_NAME { get; set; }
        public string BANK_BRANCH { get; set; }
        public string PAYMENT_REFERENCE { get; set; }
        public string PAYMENT_DATE { get; set; }
        public string DISPATCH_DATE { get; set; }
        public string DISPATCH_COURIER_DETAILS { get; set; }
        public string DEDUCTION_SEQUENCE_NUMBER { get; set; }
        public string DEDUCTION_AMOUNT { get; set; }
        public string DEDUCTION_TYPE { get; set; }
        public string DEDUCTION_REASONS { get; set; }
        public string SERVICE_TAX_AMOUNT { get; set; }
        public string FINAL_BILL_AMOUNT { get; set; }
        public string NON_PAYABLE_EXPENSES { get; set; }
        public string BUFFER_UTILISED_AMOUNT { get; set; }
        public string ROOM_RENT_DAY_OPTED { get; set; }
        public string TOTAL_ROOM_NURSING_CHARGES { get; set; }
        public string SURGERY_CHARGES { get; set; }
        public string CONSULTANT_CHARGES { get; set; }
        public string INVESTIGATION_CHARGES { get; set; }
        public string MEDICINE_CHARGES { get; set; }
        public string MISCELLANEOUS_CHARGES { get; set; }
        public string DATE_OF_PAYMENT_TO_PROVIDER { get; set; }
        public string AMOUNT_PAID_TO_PROVIDER { get; set; }
        public string BANK_CHEQUE_NO { get; set; }
        public string FLOAT_AC_NO { get; set; }
        public string CHEQUE_NO_TO_MEMBER { get; set; }
        public string BALANCE_SI { get; set; }
        public string SERVICE_TAX_NO { get; set; }
        public string TDS_AMOUNT { get; set; }
        public string REPORTED_AMOUNT { get; set; }
        public string PAID_AMOUNT { get; set; }
        public string PAID_DATE { get; set; }
        public string DATE_OF_JOINING { get; set; }
        public string INTIMATION_METHOD { get; set; }
        public string TYPE_OF_CLAIM { get; set; }
        public string CLAIM_STATUS { get; set; }
        public string STATUS_UPDATED_ON { get; set; }
        public string CLAIM_REGISTERED_DATE { get; set; }
        public string FILE_RECEIVED_DATE { get; set; }
        public string DATE_OF_SETTLEMENT { get; set; }
        public string HOSPITAL_NO { get; set; }
        public string HOSPITAL_NAME { get; set; }
        public string ADDRESS1 { get; set; }
        public string HOSPITAL_CITY { get; set; }
        public string HOSPITAL_STATE { get; set; }
        public string PIN_CODE { get; set; }
        public string DATE_OF_ADMISSION { get; set; }
        public string TIME_OF_ADMISSION { get; set; }
        public string DATE_OF_DISCHARGE { get; set; }
        public string TIME_OF_DISCHARGE { get; set; }
        public string ICD_CODE { get; set; }
        public string TREATMENT_TYPE { get; set; }
        public string TREATING_DOCTOR { get; set; }
        public string INSURANCE_COMPANY_NAME { get; set; }
        public string GROUP_NAME { get; set; }
        public string VALID_UPTO { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string SUM_INSURED { get; set; }
        public string GRADE { get; set; }
        public string SUB_GROUP { get; set; }
        public string CITY { get; set; }
        public string PARTIAL_PAYMENT_SEQUENCE { get; set; }
        public string UNIQUE_CLAIM { get; set; }
        public string PRE_AUTH_SENT { get; set; }
        public string PRE_AUTH_REQUEST_DATE { get; set; }
        public string PRE_AUTH_SENT_DATE { get; set; }
        public string PRE_AUTH_AMOUNT { get; set; }
        public string NETWORK_STATUS { get; set; }
        public string LEVEL_OF_CARE { get; set; }
        public string FINAL_DIAGNOSIS { get; set; }
        public string DISEASE_CATEGORY { get; set; }
        public string LENGTH_OF_STAY { get; set; }
        public string REJECTED_CLOSE_DATE { get; set; }
        public string STATUS { get; set; }
        public string OUTSTANDING_CLAIM_STATUS { get; set; }
        public string CASHLESS_DENIAL_REASONS { get; set; }
        public string REASON_FOR_CLOSURE { get; set; }
    }

    public class HII_ClaimData_Result_APP
    {
        public string PATIENT_NAME { get; set; }
        public string GENDER { get; set; }
        public string PATIENT_REALTION { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string AGE { get; set; }
        public string POLICY_NUMBER { get; set; }
        public string DATE_OF_ADMISSION { get; set; }
        public string STATUS { get; set; }
        public string REPORTED_AMOUNT { get; set; }
        public string FINAL_BILL_AMOUNT { get; set; }
        public string DEFICIENCY_INTIMATED_DATE { get; set; }
        public string STATUS_UPDATED_ON { get; set; }
        public string TPA_ID { get; set; }
        public string TPA_CLAIM_NO { get; set; }
        
    }

    public class ClaimIntimation
    {
        public string AilmentDescription { get; set; }
        public string ContactNo { get; set; }
        public string ProviderNumber { get; set; }
        public string DateOfAdmission { get; set; }
        public string HospName { get; set; }
        public string HospAddress { get; set; }
        public string MemberId { get; set; }
        public string PolicyNo { get; set; }
        public string AuthId { get; set; }
        public string Device { get; set; }
        public string TPA_CLAIM_NO { get; set; }

        public string TPA_ID { get; set; }
    }

    public class ClaimIntimationResPonse
    {
        public string CCN { get; set; }
        public string CCN_Ext { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class Common_UpdateAppointmentMain
    {
        public Common_UpdateAppointmentMain1 data { get; set; }
    }
    public class Common_UpdateAppointmentMain1
    {
        public Common_UpdateAppointment appointment_details { get; set; }
        public string appointment_id { get; set; }
        public string branch_id { get; set; }
        public string doctor_id { get; set; }
        public string policy_company { get; set; }
        public string policy_id { get; set; }
    }
    public class Common_UpdateAppointment
    {
        public string appointment_date { get; set; }
        public string appointment_status { get; set; }
        public string appointment_type { get; set; }
        public string cancellation_reason { get; set; }
        public string cancelled_by { get; set; }
        public string end_time { get; set; }
        public string start_time { get; set; }
    }
}
