using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class EntityClass
    {
    }

    public class EntityData
    {
        public string ENTITYID { get; set; }
        public string ENTITYCODE { get; set; }
        public string ENTITYNAME { get; set; }
        public string PASSWORD { get; set; }
        public string REGISTRATIONNO { get; set; }
        public string ADDRESS { get; set; }
        public int PINCODE { get; set; }
        public int CITY_ID { get; set; }
        public string EMAIL_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public int ENABLEPHYSICIAN { get; set; }
        public int ENABLEDIAGNOSTIC { get; set; }
        public int ENABLEPHARMACY { get; set; }
        public int ENABLEBILLINGDESK { get; set; }
        public int APPROVED { get; set; }
        public decimal DISCOUNT { get; set; }
        public string VisitorIPAddress { get; set; }
        public int REGISTERBYPAYER { get; set; }
        public decimal PHYSICAN_FEE { get; set; }
        public int SINGLEUSER { get; set; }
        public int SINGLE_PHYSICAN { get; set; }
        public int STATUSCODE { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public decimal Diagnostic_Discount { get; set; }
        public decimal Pharmacy_Discount { get; set; }
        public decimal Physican_Discount { get; set; }
        public string ADDRESS2 { get; set; }
        public string Consultant_Name { get; set; }
        public string Location { get; set; }
        public string Board_Number { get; set; }
        public string Telephone_No { get; set; }
        public string Contact_Person { get; set; }
        public string Fax_No { get; set; }
        public string Pan_No { get; set; }
        public string Payee_Name { get; set; }
        public string TDS_Type { get; set; }
        public string TDS_Code { get; set; }
        public string Effective_From { get; set; }
        public string Effective_to { get; set; }
        public string Certificate_No { get; set; }
        public string Status { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string Account_Type { get; set; }
        public string Account_no { get; set; }
        public string MICR_Code { get; set; }
        public string IFSC_Code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string cluster { get; set; }
        public string tpatype { get; set; }
        public string vendorcode { get; set; }
        public string revenue { get; set; }
        public string rohinid { get; set; }
        public string Aadhar_No { get; set; }
        public string PAYER_ID { get; set; }
        public decimal? TDS_RATE { get; set; }
        public string ATTACH_PAN { get; set; }
        public string ATTACH_AADHAR { get; set; }
        public string ATTACH_VOTERID { get; set; }
        public string ATTACH_PASSPORT { get; set; }
        public string ATTACH_MOU { get; set; }
        public string SITE_ID { get; set; }
        public string ip { get; set; }
        public string sessionid { get; set; }
        public string modifyedby { get; set; }
        public string PHARMACY_TYPE { get; set; }
        public string AGGREGATOR_TYPE { get; set; }
        public int Tele_consult { get; set; }
        public string EmailID_AppointmentBooking { get; set; }
        public string EmailID_PMT { get; set; }
        public string EmailID_CPMT { get; set; }
        public int VALOTPROLE { get; set; }
        public int ONLINE_ORDER_FLOW { get; set; }

        public decimal? Service_charge { get; set; } //change by rahul




    }

    public class PayerData
    {
        public int PAYER_ID { get; set; }
        public string PAYER_CODE { get; set; }
        public string PAYER_NAME { get; set; }
        public string SHORT_NAME { get; set; }
        public int CITY_ID { get; set; }
    }

    public class EmailData
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string SenderEmailId { get; set; }
        public string SenderPassword { get; set; }
        public string SMTPAddress { get; set; }
        public int PortNumber { get; set; }
        public bool EnableSSL { get; set; }
    }

    public class PINCODE_CITY_STATE
    {
        public int PINCODE { get; set; }
        public int CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public int STATE_ID { get; set; }
        public string STATE_NAME { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class UserRegistration
    {
        public int USER_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL_ID { get; set; }
        public string ENTITYCODE { get; set; }
        public string USERNAME { get; set; }
        public string LOGIN_ID { get; set; }
        public int USER_TYPE { get; set; }
        public string REGISTRATIONNO { get; set; }
        public int SPECIALITY_ID { get; set; }
        public string QUALIFICATION { get; set; }
        public decimal? EXPERIENCE { get; set; }
        public int QUALIFICATION_ID { get; set; }
        public string AutoPassword { get; set; }
        public int APPROVED { get; set; }
        public string VisitorIPAddress { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string SENDEMAILSMS { get; set; }
        public string CREATEUSER { get; set; }
        public string ENTITYNAME { get; set; }

        public string created_updated_by { get; set; }
    }

    public class Physican_Specliality_Fee
    {
        public string PAYERCODE { get; set; }
        public string ENTITYCODE { get; set; }
        public int SPECLIALITY_ID { get; set; }
        public decimal PHYSICAN_FEE { get; set; }
    }

    public class EntityRegistration
    {
        public string ENTITTY_CODE { get; set; }
        public string ENTITTY_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL_ID { get; set; }
        public string PASSWORD { get; set; }
        public string PAYER_ID { get; set; }
    }     
}
