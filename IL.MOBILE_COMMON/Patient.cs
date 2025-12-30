using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RN.MOBILE_COMMON
{

    [Table("Patient")]
    public class Patient : User
    {
        public int PatienID { get; set; }
        public int PrimaryMemberID { get; set; }
        public string PolicyID { get; set; }
        public string RelationShipName { get; set; }
        [Ignore]
        public Consultation Consultation { get; set; }
        [Ignore]
        public ClinicalFind ClinicalFind { get; set; }
        [Ignore]
        public List<Drug> Drugs { get; set; }
        [Ignore]
        public Entity Entity { get; set; }
        public string MemberNo { get; set; }
        public string PolicyNo { get; set; }
        public string Status { get; set; }
        [Ignore]
        public List<Diagnosis> Diagnosislist { get; set; }
        [Ignore]
        public List<PatientPayer> PatientPayerList { get; set; }
        public int pkrRelationIndex { get; set; }
        public int pkrCityIndex { get; set; }
        public int pkrIssueIndex { get; set; }
        public string GUID { get; set; }
        [Ignore]
        public List<ShippingAddress> lstShippingAdd { get; set; }
        [Ignore]
        public List<ShippingAddress> lstShippingAdd1 { get; set; }
        [Ignore]
        public List<ShippingAddress> lstHomeaddress { get; set; }
        [Ignore]
        public List<ShippingAddress> lstOfficeAddress { get; set; }
        public string Secondary_mobileno { get; set; }
        public string Secondary_emailid { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public string Address1 { get; set; }
        public string CorporateName { get; set; }
        public string EmployeeID { get; set; }
        public int IsRegistred { get; set; }
        public int MobEMaiReverseUpdateReq { get; set; }
        public int IsSelfMemberRegistered { get; set; }
        public int IsSelfMemberActive { get; set; }
        public int PolicyStatus { get; set; }
        public int PolicyExpired { get; set; }
        public string PayeeName { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string corporate_id { get; set; }
        public int rn_relation_id { get; set; }
        public int REM_ENABLED { get; set; }
        public string user_name_without_mrms { get; set; }
        public string OFFLINE_PRESC_ENABLED { get; set; }
    }
    public class PatientPayer
    {
        public string MemberNo { get; set; }
        public int PayerID { get; set; }
        public string payerCode { get; set; }
        public string PayerName { get; set; }
        public string PayerCode { get; set; }
        public string MemberName { get; set; }
        public int PatientID { get; set; }
    }
    public class PatientMediDetails
    {
        public string Hypertension { get; set; }
        public string Diabetics { get; set; }
        public string HartDisease { get; set; }
        public string COPD { get; set; }
        public string STD { get; set; }
        public string PreOthers { get; set; }
        public string Asthma { get; set; }
        public string Cancer { get; set; }
        public string Epilepsy { get; set; }
        public string Arthritis { get; set; }
        public string Congent_diseases { get; set; }
        public string Smoking { get; set; }

    }
    public class RecieptDetails
    {
        public string CLAIM_ID { get; set; }
        public int TRANSACTION_TYPE { get; set; }
        public string BILL_AMOUNT { get; set; }
        public string PAYABLE_AMOUNT { get; set; }
        public string PAYER_PAYABLE { get; set; }
        public string PATIENT_PAYABLE { get; set; }
        public string ORDER_ID { get; set; }
        public string PAYER_ORDER_ID { get; set; }
        public string PRESC_FILENAME { get; set; }
        public string AGGREGATOR_TYPE { get; set; }
        public string PHARMACY_TYPE { get; set; }
        public string INVOICE_FILENAME { get; set; }

        public string online_order_flow { get; set; }
    }
    public class PatientPolicyDetails
    {
        public Patient Patient { get; set; }
        public List<Patient> Patient_LIST { get; set; }
        public int IsOrderCompleted { get; set; }
    }

    //public class Issues
    //{
    //    public int VALUE_ID { get; set; }
    //    public string VALUE_DESC { get; set; }
    //    public string VALUE_CODE { get; set; }
    //    public string ToEmailId { get; set; }
    //}
    public class CustomerIssue
    {
        public int ISSUE_ID { get; set; }

        public string ISSUE_NAME { get; set; }

        public string ISSUE_DESCRIPTION { get; set; }

        public string PatienID { get; set; }

        public string Payercode { get; set; }

        public string ToEmailId { get; set; }

        public string CREATED_BY { get; set; }

        public string MODIFIED_BY { get; set; }

        public string DEVICEID { get; set; }

        public string VISITORSIP { get; set; }
    }
    public class ShippingAddress
    {
        public string AddressId { get; set; }
        public string AddressTitle { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string PinCode { get; set; }
        public string CityID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateID { get; set; }
        public string MobileNo { get; set; }
        public string Country { get; set; }

        public string consumer_name { get; set; }
        public string primary_emailid { get; set; }
        public string secondary_emailid { get; set; }
        public string company_name { get; set; }
        public string address_type { get; set; }
        public string locality { get; set; }
        public string UserID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceID { get; set; }
        public string Integration_id { get; set; }
        public string Integration_Address_Id { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string patientid { get; set; }
    }
    public class EcardDetails
    {
        public string CompanyName { get; set; }
        public string EmployeeId { get; set; }
        public string ValidTo { get; set; }
        public string PatientId { get; set; }
        public string PrimaryPatientId { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string CardNo { get; set; }
        public string ValidFrom { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string MemeberId { get; set; }
        public string RelationShipName { get; set; }
        public string PolicyNumber { get; set; }
        public int PolicyType { get; set; }
        public int ProductType { get; set; }

        public int Status { get; set; }
        public int IntegrationType { get; set; }
        public string EcardURL { get; set; }
    }
    public class Resend_otp
    {
        public string ENTITY_CODE { get; set; }
        public string PATIENT_PAYABLE { get; set; }
        public string ELIGIBLE_AMOUNT { get; set; }
        public string OTP_VALUE { get; set; }
        public string INTEGRATION_APPOINTMENT_ID { get; set; }

    }
}
