using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{

    public class Appointment
    {
        public string LastFetchTime { get; set; }
        public int AppointmentID { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public int EntityID { get; set; }
        public int SlotID { get; set; }
        public string SlotTime { get; set; }
        public int SlotType { get; set; }
        public string AppointmentDate { get; set; }
        public string BookedDate { get; set; }
        public string MemberID { get; set; }
        public string PolicyNo { get; set; }
        public decimal EligibleAmt { get; set; }
        public string PatientPayable { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string PatientRelationShip { get; set; }
        public string PatientGender { get; set; }
        public string PhysicianName { get; set; }
        public int SpecialityID { get; set; }
        public string SpecialityDec { get; set; }
        public string EntityName { get; set; }
        public decimal ConsultFee { get; set; }
        public string Experience { get; set; }
        public int ServiceType { get; set; }
        public string EntityCode { get; set; }
        public string MemberName { get; set; }
        public int Status { get; set; }
        public string SearchBySpeciality { get; set; }
        public string SearchByConsultant { get; set; }
        public int Integration_Id { get; set; }
        public string Intergration_code { get; set; }
        public string Status_Desc { get; set; }
        public string ServiceTypeDesc { get; set; }
        public int CAN_CANCEL { get; set; }
        public string PayerCode { get; set; }
        public string Service_Code { get; set; }
        public string PaymentMode { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ServiceCharge { get; set; }
        public bool IsFleboCharge { get; set; }
        public string InvoiceNumber { get; set; }
        public string PaidDate { get; set; }
        public string PAID_STATUS { get; set; }
        public int INSURED_MEMBER { get; set; }
        public string Integration_Appointment_Id { get; set; }
        public int BookedBy { get; set; }
        public string APP_GUID { get; set; }
        public string diagnostic_prescription_id { get; set; }
        public DateTime OrderByAppDate { get; set; }
        public string PatientEmailID { get; set; }
        public string PatientMobileNo { get; set; }
        public string PractoAcessToken { get; set; }
        public string EntityMobileNo { get; set; }
        public int Is_reschedule { get; set; }
        public int MODIFIED_BY { get; set; }
        public string VISITORIP { get; set; }
        public string DEVICEID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int City_ID { get; set; }
        public string CANCEL_REASON { get; set; }
        public string IS_WALKIN { get; set; }
        public int APPOINTMENT_BY_ADMIN { get; set; }
        public string SlotEndTime { get; set; }
        public string appointment_status { get; set; }
        public string payment_link { get; set; }
        public string Vist_Type { get; set; }
        public string aggregatorType { get; set; }
        public string diatnosticTestCodes { get; set; }
        public string Consultation_Type { get; set; }
        public string Video_Consult_Link { get; set; }
        public string authorizationCode { get; set; }
    }

    public class PhysicianSlotList
    {
        public int PhysicianID { get; set; }

        public string PhysicianName { get; set; }

        public string EveningSlot { get; set; }

        public string MorningSlot { get; set; }

        public string AfternoonSlot { get; set; }

        public int SlotActiveM { get; set; }

        public int SlotActiveA { get; set; }

        public int SlotActiveE { get; set; }

        public decimal ConsultFee { get; set; }

        public string Speciality { get; set; }

        public string Experience { get; set; }
        public string SpecialityId { get; set; }
        public string ProviderName { get; set; }
        public int ProviderID { get; set; }
        public string ProviderCode { get; set; }
        public string PractoDoctorId { get; set; }
    }

    public class AppointmentSlotList
    {
        public int SlotID { get; set; }
        public int SlotType { get; set; }
        public string Slot { get; set; }
        public string SlotStatus { get; set; }
        public string SlotEndTime { get; set; }
        public string transaction_id { get; set; }
    }

    public class SearchCretirya
    {
        public int Pincode { get; set; }
        public string Specialty { get; set; }
        public string Consultant { get; set; }
        public string AppointmentDate { get; set; }
        public string ProviderName { get; set; }
        public string Prescription { get; set; }
        public string Diagnosis { get; set; }
        public string HealthChekup { get; set; }
        public string SearchKey { get; set; }
        public string PayerCode { get; set; }
        public bool isEligibilityChk { get; set; }
        public string SpecialtyID { get; set; }
        public string ProviderCode { get; set; }
        public List<Diagnosis> Diagnosislist { get; set; }
    }

    public class AppSlotMaster
    {
        public int SlotID { get; set; }

        public int SlotType { get; set; }
        public string SlotFrom { get; set; }

        public string SlotTo { get; set; }

        public int Interval { get; set; }
        public int Day { get; set; }
    }

    public class BSI_DEDUCTION_INT
    {
        public string memberid { get; set; }
        public string approvedamount { get; set; }
        public string guid { get; set; }
        public string isreimbursment { get; set; }
        public string appointmentid { get; set; }
        public string integrationid { get; set; }
    }

    public class INTEGRATION_REQ_RES_DATA
    {
        public int requestid { get; set; }
        public string method_code { get; set; }
        public string member_id { get; set; }
        public int otp { get; set; }
        public string claim_id { get; set; }
        public string transaction_id { get; set; }
        public string EntityCode { get; set; }
        public string PatPayableAmt { get; set; }
        public string PayerPayableAmt { get; set; }
        public string Patient_Id { get; set; }
        public string IntAppointmentId { get; set; }
        public int IntegrationId { get; set; }
    }

    public class DelayedPayents
    {
        public int appointmentID { get; set; }

        public string order_id { get; set; }
        public string prescription_id { get; set; }
        public string entityCode { get; set; }

        public int TransactionType { get; set; }
    }
}
