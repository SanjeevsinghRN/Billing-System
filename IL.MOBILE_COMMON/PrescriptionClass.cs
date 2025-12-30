using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{
    public class PrescriptionClass
    {
        public string prescriptionId { get; set; }
        public string patientName { get; set; }
        public string physicianName { get; set; }
        public string pharmacyId { get; set; }
        [Ignore]
        public Pharmacy pharmacyDetail { get; set; }
        public string prescriptionDate { get; set; }
        public string ailmentCode { get; set; }
        public string ailmentName { get; set; }
        public string ailmentid { get; set; }
        [Ignore]
        public List<Drug> Druglist { get; set; }
        [Ignore]
        public List<Procedure> Proclist { get; set; }
        [Ignore]
        public List<Procedure> Testlist { get; set; }
        public int selected { get; set; }
        public string patient_id { get; set; }
        public string physician_id { get; set; }
        public int PrescriptionType { get; set; }
        public string DeliveryPinCode { get; set; }
        public string DeliveryState { get; set; }
        public string DeliveryCity { get; set; }
        public string PrecFileName { get; set; }
        public string DeliveryAddress { get; set; }
        public byte[] PrecImage { get; set; }
        public string diagnosticId { get; set; }
        [Ignore]
        public Diagnostic DiagnosticDetail { get; set; }
        [Ignore]
        public List<Diagnosis> DiagnosisDetail { get; set; }
        public int UnreadMsgCount { get; set; }
        [Ignore]
        public List<Oderdetails> PharmacyOderdetails { get; set; }
        [Ignore]
        public List<Oderdetails> Orderdetails { get; set; }
        public string ChatDate { get; set; }
        public Int16 ChatPayable { get; set; }
        public decimal ChatAmount { get; set; }
        public string WalletAmt { get; set; }
        public string PatientGender { get; set; }
        public string PatientAge { get; set; }
        public decimal BillAmt { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalBillAmt { get; set; }
        public string GUID { get; set; }
        public bool IsCashLess { get; set; }
        public string MemberID { get; set; }
        public string MobileNo { get; set; }
        public string PayerName { get; set; }
        public string prescriptionTime { get; set; }
        public bool IsView { get; set; }
        public string PAYMENT_DATE { get; set; }
        public string Remarks { get; set; }
        [Ignore]
        public ClinicalFind ClinicalFind { get; set; }
        [Ignore]
        public Consultation Consultation { get; set; }
        //public Entity Entity { get; set; }
        public string TransactionType { get; set; }
        public string payerId { get; set; }
        public string payerCode { get; set; }
        [Ignore]
        public List<Payment> paymentList { get; set; }
        [Ignore]
        public PolicyValidation policyValidation { get; set; }
        public string paymentID { get; set; }
        public string orderID { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public bool IsBillingDesk { get; set; }
        public string EntityCode { get; set; }
        public string PharmacyRemarks { get; set; }
        public string TreatmentMethod { get; set; }
        public int IsAppointment { get; set; }
        public int Is_health_check { get; set; }
        [Ignore]
        public HealthCheckup HCU { get; set; }
        public int AppointmentId { get; set; }
        [Ignore]
        public Diagnosis Diagnosis { get; set; }
        public int EntityId { get; set; }
        public int NoBSIDeduct { get; set; }
        public string EntityName { get; set; }

        public string procedureCode { get; set; }
        public string procedureName { get; set; }
        public string procedureid { get; set; }
        [Ignore]
        public List<Drug> PrescDruglist { get; set; }
        public string ServiceAccessTypeID { get; set; }
        public int IsFollowUpCase { get; set; }
        public string FollowUp_prescriptionId { get; set; }

        public string TOTAL_PROCEDURE_APP_AMT { get; set; }
        public string TOTAL_TEST_APP_AMT { get; set; }
        public string INTERNALINVOICENO { get; set; }
        [Ignore]
        public ShippingAddress ShippingAdr { get; set; }
        public string EntityKey { get; set; }
        [Ignore]
        public List<Diagnosis> Diagnosis_ailment_Detail { get; set; }

        [Ignore]
        public List<Ailment> Ailment_Details { get; set; }

        [Ignore]
        public List<complaint> complaints { get; set; }

        public string practo_claimid { get; set; }
        public int AutoShowReport { get; set; }
        public string SerializeDrugList()
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(this.Druglist.GetType());
            serializer.Serialize(stringwriter, this.Druglist);
            return stringwriter.ToString();
        }

        public class complaint
        {
            public string name { get; set; }
            public string Prescription_id { get; set; }
        }
        [Ignore]
        public List<OP_Attachments> AttachmentsLst { get; set; }
        [Ignore]
        public List<Vital_Controls> VitalsLst { get; set; }
        [Ignore]
        public List<DiagnosticRange> Diagnostic_Range { get; set; }
        public string Vital_ID { get; set; }

        [Ignore]
        public List<SecondaryAilment> secondaryAilments { get; set; }

        public string Action_status { get; set; }
        public string Action_status_Id { get; set; }
        public string Payer_remarks { get; set; }
        public class SecondaryAilment
        {
            public string SecondaryAilmentId { get; set; }
            public string SecondaryAilmentname { get; set; }
        }

        public string INVOICE_NUMBER { get; set; }

        public string TRANSACTION_STATUS { get; set; }
        [XmlIgnore]
        public Nullable<DateTime> OrderByModifiedDate { get; set; }

        public Int32 HasDiagnostic { get; set; }
        public Int32 HasDiagnosticOrder { get; set; }
        [XmlIgnore]
        public Nullable<DateTime> OrderByOrderDate { get; set; }
        [XmlIgnore]
        public Nullable<DateTime> OrderByPrescDate { get; set; }

        public Int32 HasDrug { get; set; }

        public Int32 HasPharmachyOrder { get; set; }

        [Ignore]
        public List<Feedback> FeedBackDetails { get; set; }

        public Int32 Hasfeedback { get; set; }

        public string LastFetchTime { get; set; }

        public string physician_Speciality { get; set; }

        public string PayerPayable { get; set; }

        public string PatientPayable { get; set; }

        public string total_billAmount { get; set; }

        public string is_checkbalance { get; set; }
        [Ignore]
        public List<Procedure> checkbalance_trans_list { get; set; }
        public string CREATED_BY { get; set; }

        public string MODIFIED_BY { get; set; }

        public string DEVICEID { get; set; }

        public string VISITORIP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int City_ID { get; set; }
        public bool Ispharmacyordered { get; set; }
        public string TOTAL_BILL_AMOUNT { get; set; }
        public string TOTAL_PAYER_PAYABLE { get; set; }
        public string TOTAL_PATIENT_PAYABLE { get; set; }
        public int IsOfflinePrescription { get; set; }
        public int prescription_type { get; set; }
        public string PRESC_CONSULTATION_FILENAME { get; set; }
        [Ignore]
        public PrescriptionUpload offlinePrescription { get; set; }
        public string ReferalID { get; set; }
        public int Aggregator_type { get; set; }
        public string consultInvoiceFileName { get; set; }
        public string intAppointmentId { get; set; }
    }

    public class PrescriptionClassPracto
    {
        //public string physicianName { get; set; }
        public string pharmacyId { get; set; }
        //[Ignore]
        //public Pharmacy pharmacyDetail { get; set; }
        //public string prescriptionDate { get; set; }
        //public string ailmentName { get; set; }
        //public string DeliveryPinCode { get; set; }
        //public string DeliveryState { get; set; }
        // public string DeliveryCity { get; set; }
        // public string PrecFileName { get; set; }
        // public string DeliveryAddress { get; set; }
        //public byte[] PrecImage { get; set; }
        //public string ChatDate { get; set; }
        //public Int16 ChatPayable { get; set; }
        //public decimal ChatAmount { get; set; }
        //public string WalletAmt { get; set; }
        //public string PatientGender { get; set; }
        //public string PatientAge { get; set; }
        //public bool IsView { get; set; }
        //public string PAYMENT_DATE { get; set; }
        //public string Remarks { get; set; }
        //[Ignore]
        //public List<OP_Attachments> AttachmentsLst { get; set; }
        //[Ignore]
        //public List<Vital_Controls> VitalsLst { get; set; }
        //[Ignore]
        //public List<DiagnosticRange> Diagnostic_Range { get; set; }
        //[Ignore]
        //public string Vital_ID { get; set; }
        //[Ignore]
        //public List<SecondaryAilment> secondaryAilments { get; set; }
        //public class SecondaryAilment
        //{
        //    public string SecondaryAilmentId { get; set; }
        //    public string SecondaryAilmentname { get; set; }
        //}
        //  public string INVOICE_NUMBER { get; set; }
        //  public string TRANSACTION_STATUS { get; set; }
        // public int selected { get; set; }
        //[Ignore]
        //public Diagnostic DiagnosticDetail { get; set; }
        //[Ignore]
        //public ClinicalFind ClinicalFind { get; set; }
        //[Ignore]
        //public Consultation Consultation { get; set; }
        //public string diagnosticId { get; set; }
        //public int UnreadMsgCount { get; set; }
        //[Ignore]
        //public List<Oderdetails> PharmacyOderdetails { get; set; }
        //[Ignore]
        //public List<Oderdetails> Orderdetails { get; set; }
        public decimal BillAmt { get; set; }
        //public decimal Discount { get; set; }
        //public decimal TotalBillAmt { get; set; }
        //public string MobileNo { get; set; }
        //public string PayerName { get; set; }
        //public string prescriptionTime { get; set; }
        //public string PharmacyRemarks { get; set; }
        //[Ignore]
        //public Diagnosis Diagnosis { get; set; }
        //public int EntityId { get; set; }
        //public int NoBSIDeduct { get; set; }
        //public string EntityName { get; set; }
        //public string procedureCode { get; set; }
        //public string procedureName { get; set; }
        //public string procedureid { get; set; }
        //[Ignore]
        //public List<Drug> PrescDruglist { get; set; }
        //public string ServiceAccessTypeID { get; set; }
        //public string TOTAL_PROCEDURE_APP_AMT { get; set; }
        //public string TOTAL_TEST_APP_AMT { get; set; }
        //public string INTERNALINVOICENO { get; set; }
        //[Ignore]
        //public ShippingAddress ShippingAdr { get; set; }
        //public string EntityKey { get; set; }
        //public int AutoShowReport { get; set; }
        //public string SerializeDrugList()
        //{
        //    var stringwriter = new System.IO.StringWriter();
        //    var serializer = new XmlSerializer(this.Druglist.GetType());
        //    serializer.Serialize(stringwriter, this.Druglist);
        //    return stringwriter.ToString();
        //}
        //public Entity Entity { get; set; }
        //public int IsAppointment { get; set; }
        //public int Is_health_check { get; set; }
        //[Ignore]
        //public HealthCheckup HCU { get; set; }
        public List<OrderedDrug> OrderedDrugList { get; set; }
        public int AppointmentId { get; set; }
        public string GUID { get; set; }
        public bool IsCashLess { get; set; }
        public string prescriptionId { get; set; }
        public string patientName { get; set; }
        public string ailmentCode { get; set; }
        public string ailmentid { get; set; }
        [Ignore]
        public List<Drug> Druglist { get; set; }
        [Ignore]
        public List<Procedure> Proclist { get; set; }
        [Ignore]
        public List<Procedure> Testlist { get; set; }

        public string patient_id { get; set; }
        public string physician_id { get; set; }
        public int PrescriptionType { get; set; }
        [Ignore]
        public List<Diagnosis> DiagnosisDetail { get; set; }
        public string MemberID { get; set; }
        public string TransactionType { get; set; }
        public string payerId { get; set; }
        public string payerCode { get; set; }
        [Ignore]
        public List<Payment> paymentList { get; set; }
        [Ignore]
        public PolicyValidation policyValidation { get; set; }
        public string paymentID { get; set; }
        public string orderID { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public bool IsBillingDesk { get; set; }
        public string EntityCode { get; set; }
        public string TreatmentMethod { get; set; }
        public int IsFollowUpCase { get; set; }
        public string FollowUp_prescriptionId { get; set; }
        [Ignore]
        public List<Diagnosis> Diagnosis_ailment_Detail { get; set; }
        [Ignore]
        public List<complaint> complaints { get; set; }
        [Ignore]
        public List<Ailment> Ailment_Details { get; set; }
        public string practo_claimid { get; set; }
        public class complaint
        {
            public string name { get; set; }
        }

        public class OrderedDrug
        {
            public string DRUG_ID { get; set; }
            public string DRUG_CODE { get; set; }
            public string DRUG_NAME { get; set; }
            public string QUNTITY { get; set; }
            public string DRUG_TYPE { get; set; }
            public string MRP { get; set; }
            public string DISCOUNT { get; set; }
            public string OFFER_PRICE { get; set; }
            public string RATE { get; set; }
            public string SUBSTITUTE_WITH_ITEM_ID { get; set; }
            public string PAYER_DRUG_CODE { get; set; }
            public string PAYER_DRUG_NAME { get; set; }
            public string PAYER_RATE { get; set; }
            public string PAYER_UNIT { get; set; }
            public string PAYER_AMOUNT { get; set; }
            public string PAYER_AMOUNTITEM_CODE { get; set; }

        }

        public string CREATED_BY { get; set; }

        public string MODIFIED_BY { get; set; }

        public string DEVICEID { get; set; }

        public string VISITORIP { get; set; }
        public string Integration_claimId { get; set; }
        public int Integration_id { get; set; }
    }

    public class PrescriptionClassIntegration
    {
        public string pharmacyId { get; set; }
        public decimal BillAmt { get; set; }
        public List<OrderedDrug> OrderedDrugList { get; set; }
        public int AppointmentId { get; set; }
        public string GUID { get; set; }
        public bool IsCashLess { get; set; }
        public string prescriptionId { get; set; }
        public string patientName { get; set; }
        public string ailmentCode { get; set; }
        public string ailmentid { get; set; }
        [Ignore]
        public List<Drug> Druglist { get; set; }
        [Ignore]
        public List<Procedure> Proclist { get; set; }
        [Ignore]
        public List<Procedure> Testlist { get; set; }
        public string patient_id { get; set; }
        public string physician_id { get; set; }
        public int PrescriptionType { get; set; }
        [Ignore]
        public List<Diagnosis> DiagnosisDetail { get; set; }
        public string MemberID { get; set; }
        public string TransactionType { get; set; }
        public string payerId { get; set; }
        public string payerCode { get; set; }
        [Ignore]
        public List<Payment> paymentList { get; set; }
        [Ignore]
        public PolicyValidation policyValidation { get; set; }
        public string paymentID { get; set; }
        public string orderID { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public bool IsBillingDesk { get; set; }
        public string EntityCode { get; set; }
        public string TreatmentMethod { get; set; }
        public int IsFollowUpCase { get; set; }
        public string FollowUp_prescriptionId { get; set; }
        [Ignore]
        public List<Diagnosis> Diagnosis_ailment_Detail { get; set; }
        [Ignore]
        public List<complaint> complaints { get; set; }
        [Ignore]
        public List<Ailment> Ailment_Details { get; set; }
        public string practo_claimid { get; set; }
        public class complaint
        {
            public string name { get; set; }
        }
        public class OrderedDrug
        {
            public string DRUG_ID { get; set; }
            public string DRUG_CODE { get; set; }
            public string DRUG_NAME { get; set; }
            public string QUNTITY { get; set; }
            public string DRUG_TYPE { get; set; }
            public string MRP { get; set; }
            public string DISCOUNT { get; set; }
            public string OFFER_PRICE { get; set; }
            public string RATE { get; set; }
            public string SUBSTITUTE_WITH_ITEM_ID { get; set; }
            public string PAYER_DRUG_CODE { get; set; }
            public string PAYER_DRUG_NAME { get; set; }
            public string PAYER_RATE { get; set; }
            public string PAYER_UNIT { get; set; }
            public string PAYER_AMOUNT { get; set; }
            public string PAYER_AMOUNTITEM_CODE { get; set; }

        }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string DEVICEID { get; set; }
        public string VISITORIP { get; set; }
        public string Integration_claimId { get; set; }
        public int Integration_id { get; set; }
        public Consultation Consultation { get; set; }
    }

    public class PrescriptionUpload
    {
        public string Phy_Name { get; set; }
        public string Clinic_Name { get; set; }
        public string Phy_ConNumber { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Presc_Content { get; set; }
        public string Uploaded_FileName { get; set; }
        public string Patient_Id { get; set; }
        public string Member_ID { get; set; }
        public string Presc_Date { get; set; }
        public string Presc_Fee { get; set; }
        public string GUId { get; set; }
        public string Device_ID { get; set; }
        public string Vister_IP { get; set; }
        public string PayerCode { get; set; }
        public string Action_Status { get; set; }
        public string PRESC_ID { get; set; }
        public string Previous_FileName { get; set; }
        public string POLICY_NUMBER { get; set; }
        public string PAYER_REMARKS { get; set; }
        public string MAKER_REMARKS { get; set; }
        public string CHECKER_REMARKS { get; set; }
        public string QUERY_REASON_ID { get; set; }
        public string QUERY_REASON { get; set; }
    }


    public class TeleConsult_Prescription
    {
        public string CustomerName { get; set; }
        public string specialtyCode { get; set; }
        public string HospitalName { get; set; }
        public string HospitalCode { get; set; }
        public string entitycode { get; set; }
        public string DoctorName { get; set; }
        public string Doctor_registeration { get; set; }
        public string UHID { get; set; }
        public string PolicyNo { get; set; }
        public string Email { get; set; }
        public string mobile { get; set; }
        public string remarks { get; set; }
        public string Presc_Content { get; set; }
        public string PDF_Prescription { get; set; }
        public string Patient_Id { get; set; }
        public string GUId { get; set; }
        public string Device_ID { get; set; }
        public string Vister_IP { get; set; }
        public string PayerCode { get; set; }

        public string PHYSICIAN_ID { get; set; }

    }
}
